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
    public class UpdateProfileTargetCommandHandler : IRequestHandler<UpdateProfileTargetCommand, ResultWrapper<UpdateProfileTargetOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateProfileTargetCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<UpdateProfileTargetOutput>> Handle(UpdateProfileTargetCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateProfileTargetOutput> updateProfileResult = new ResultWrapper<UpdateProfileTargetOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "User doesn't exists";
                return updateProfileResult;
            }

            if (tUser.Weight <= request.TargetWeight && request.GoalId == (int)AppEnums.GoalEnum.LOSE_WEIGHT)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Target weight is invalid!";
                return updateProfileResult;
            }
            if (tUser.Weight >= request.TargetWeight && request.GoalId == (int)AppEnums.GoalEnum.GAIN_WEIGHT)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Target weight is invalid!";
                return updateProfileResult;
            }
            if (tUser.Weight != request.TargetWeight && request.GoalId == (int)AppEnums.GoalEnum.MAINTAIN_WEIGHT)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Target weight is invalid!";
                return updateProfileResult;
            }

            if (!_dbContext.TActivityLevel.Any(x => x.Id == request.ActivityLevelId))
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "select your activity level!";
                return updateProfileResult;
            }
            if (!_dbContext.TWeeklyGoal.Any(x => x.Id == request.WeeklyGoalId))
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "select your weekly goal!";
                return updateProfileResult;
            }

            tUser.TActivityLevelId = request.ActivityLevelId;
            tUser.TWeeklyGoalId = request.WeeklyGoalId;
            tUser.TargetWeight = request.TargetWeight;
            _dbContext.TUser.Update(tUser);
            int r = await _dbContext.SaveChangesAsync();

            if (r <= 0)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Unhandled error!";
                return updateProfileResult;
            }

            updateProfileResult.Status = true;
            updateProfileResult.Result = new UpdateProfileTargetOutput()
            {
            };

            return updateProfileResult;
        }
    }
}