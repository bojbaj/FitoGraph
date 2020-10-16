using System;
using System.Collections.Generic;
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
    public class UpdateProfileActivitiesCommandHandler : IRequestHandler<UpdateProfileActivitiesCommand, ResultWrapper<UpdateProfileActivitiesOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateProfileActivitiesCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<UpdateProfileActivitiesOutput>> Handle(UpdateProfileActivitiesCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateProfileActivitiesOutput> updateProfileResult = new ResultWrapper<UpdateProfileActivitiesOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "User doesn't exists";
                return updateProfileResult;
            }

            List<TUserSport> userSports = _dbContext.TUserSport.Where(x => x.TUser.FireBaseId == request.firebaseId).ToList();
            _dbContext.TUserSport.RemoveRange(userSports.Where(x => !request.Activities.Contains(x.TSportId)));

            int selectedSportsCount = _dbContext.TSport.Where(x => request.Activities.Contains(x.Id)).Count();
            if (selectedSportsCount != request.Activities.Count)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Selected activities are invalid!";
                return updateProfileResult;
            }
            foreach (int sportId in request.Activities.Where(x => !userSports.Any(z => z.TSportId == x)))
            {
                _dbContext.TUserSport.Add(new TUserSport()
                {
                    TUserId = tUser.Id,
                    TSportId = sportId
                });
            }
            int r = await _dbContext.SaveChangesAsync();

            if (r <= 0)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Unhandled error!";
                return updateProfileResult;
            }

            updateProfileResult.Status = true;
            updateProfileResult.Result = new UpdateProfileActivitiesOutput()
            {
            };

            return updateProfileResult;
        }
    }
}