using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, ResultWrapper<UpdateSupplierOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateSupplierCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<UpdateSupplierOutput>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateSupplierOutput> createUserResult = new ResultWrapper<UpdateSupplierOutput>();
            try
            {
                GenderEnum GenderEn = GenderEnum.NULL;
                if (!Enum.TryParse<GenderEnum>(request.Gender.ToString(), true, out GenderEn))
                {
                    createUserResult.Status = false;
                    createUserResult.Message = "Gender value is invalid!";
                    return createUserResult;
                }

                TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.Id == request.Id);
                if (tUser == null)
                {
                    createUserResult.Status = false;
                    createUserResult.Message = "cannot find supplier!";
                    return createUserResult;
                }

                tUser.Gender = request.Gender;
                tUser.FirstName = request.FirstName;
                tUser.LastName = request.LastName;
                tUser.Address = request.Address;
                tUser.PostalCode = request.PostalCode;
                tUser.Phone = request.Phone;
                tUser.TRegionCityId = request.RegionCityId;
                tUser.RestaurantName = request.RestaurantName;
                _dbContext.Update(tUser);
                await _dbContext.SaveChangesAsync();

                createUserResult.Status = true;
                createUserResult.Result = new UpdateSupplierOutput()
                {
                    Id = tUser.Id,
                    Email = tUser.Email,
                    FireBaseId = tUser.FireBaseId
                };
            }
            catch (Exception ex)
            {
                createUserResult.Status = false;
                createUserResult.Message = ex.Message;
            }
            return createUserResult;
        }
    }
}