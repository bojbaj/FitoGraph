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
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, ResultWrapper<CreateSupplierOutput>>
    {
        private readonly AppDbContext _dbContext;
        public CreateSupplierCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<CreateSupplierOutput>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CreateSupplierOutput> createUserResult = new ResultWrapper<CreateSupplierOutput>();
            try
            {
                GenderEnum GenderEn = GenderEnum.NULL;
                if (!Enum.TryParse<GenderEnum>(request.Gender.ToString(), true, out GenderEn))
                {
                    createUserResult.Status = false;
                    createUserResult.Message = "Gender value is invalid!";
                    return createUserResult;
                }

                TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.Email == request.Email);
                if (tUser == null)
                {
                    tUser = new TUser()
                    {
                        Email = request.Email,
                        FireBaseId = request.FireBaseId,
                        Enabled = true,
                        Gender = request.Gender,
                        Role = request.Role,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Address = request.Address,
                        PostalCode = request.PostalCode,
                        Phone = request.Phone,
                        TRegionCityId = request.RegionCityId,
                        RestaurantName = request.RestaurantName,
                        ShareAccount = request.ShareAccount,
                        SharePercent = request.SharePercent
                    };
                    _dbContext.TUser.Add(tUser);
                }
                else
                {
                    tUser.FireBaseId = request.FireBaseId;
                    tUser.Gender = request.Gender;
                    tUser.FirstName = request.FirstName;
                    tUser.LastName = request.LastName;
                    tUser.Address = request.Address;
                    tUser.PostalCode = request.PostalCode;
                    tUser.Phone = request.Phone;
                    tUser.TRegionCityId = request.RegionCityId;
                    tUser.RestaurantName = request.RestaurantName;
                    tUser.ShareAccount = request.ShareAccount;
                    tUser.SharePercent = request.SharePercent;
                }
                await _dbContext.SaveChangesAsync();
                createUserResult.Status = true;
                createUserResult.Result = new CreateSupplierOutput()
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