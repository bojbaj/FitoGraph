using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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

namespace FitoGraph.Api.Commands.Handler
{
    public class UpdateProfileBaseInfoCommandHandler : IRequestHandler<UpdateProfileBaseInfoCommand, ResultWrapper<UpdateProfileBaseInfoOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateProfileBaseInfoCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<UpdateProfileBaseInfoOutput>> Handle(UpdateProfileBaseInfoCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateProfileBaseInfoOutput> updateProfileResult = new ResultWrapper<UpdateProfileBaseInfoOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "User doesn't exists";
                return updateProfileResult;
            }

            tUser.FirstName = request.FirstName;
            tUser.LastName = request.LastName;
            tUser.BirthYear = request.BirthYear;
            tUser.PostalCode = request.PostalCode;
            tUser.Address = request.Address;
            tUser.TRegionCityId = request.CityId;
            _dbContext.TUser.Update(tUser);
            int r = await _dbContext.SaveChangesAsync();

            if (r <= 0)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Unhandled error!";
                return updateProfileResult;
            }

            updateProfileResult.Status = true;
            updateProfileResult.Result = new UpdateProfileBaseInfoOutput()
            {
            };

            return updateProfileResult;
        }
    }
}