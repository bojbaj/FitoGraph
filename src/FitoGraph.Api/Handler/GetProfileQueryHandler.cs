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
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ResultWrapper<GetProfileOutput>>
    {
        private readonly AppDbContext _dbContext;
        public GetProfileQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetProfileOutput>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetProfileOutput> result = new ResultWrapper<GetProfileOutput>();

            TUser tUser = await _dbContext.TUser
                .Include(x => x.TBodyType)
                .Include(x => x.TRegionCity).ThenInclude(x => x.TRegionState)
                .Include(x => x.TActivityLevel)
                .Include(x => x.TWeeklyGoal)
                .FirstOrDefaultAsync(x => x.FireBaseId == request.firebaseId);

            result.Status = true;
            result.Result = new GetProfileOutput()
            {
                Email = tUser.Email,
                FireBaseId = tUser.FireBaseId,
                Enabled = tUser.Enabled,
                FirstName = tUser.FirstName,
                LastName = tUser.LastName,
                BirthYear = tUser.BirthYear,
                Phone = tUser.Phone,
                Address = tUser.Address,
                PostalCode = tUser.PostalCode,
                RegionCityId = tUser.TRegionCityId.toInt(0),
                RegionStateId = tUser.TRegionCity?.TRegionStateId.toInt(0) ?? 0,
                RegionCountryId = tUser.TRegionCity?.TRegionState?.TRegionCountryId.toInt(0) ?? 0,
                Weight = tUser.Weight,
                Height = tUser.Height,
                Waist = tUser.Waist,
                Hips = tUser.Hips,
                Forearms = tUser.Forearms,
                Fat = tUser.Fat,
                BodyType = tUser.TBodyType == null ? new BodyTypeOutput() : new BodyTypeOutput()
                {
                    Id = tUser.TBodyType.Id,
                    Title = tUser.TBodyType.Title,
                    Image = tUser.TBodyType.Image
                },
                ActivityLevelPalForMale = tUser.TActivityLevel?.PALForMale ?? 0,
                ActivityLevelPalForFemale = tUser.TActivityLevel?.PALForFeMale ?? 0,
                ActivityLevelCarb = tUser.TActivityLevel?.Carb ?? 0,
                ActivityLevelProtein = tUser.TActivityLevel?.Protein ?? 0,
                Gender = tUser.Gender,
                TargetWeight = tUser.TargetWeight,
                WeeklyGoalId = tUser.TWeeklyGoalId ?? 0,
                WeeklyGoalCaloryPercent = tUser.TWeeklyGoal?.CaloryRequirePercent ?? 0,
                GoalId = tUser.TWeeklyGoal?.TGoalId ?? 0,
                ActivityLevelId = tUser.TActivityLevelId ?? 0
            };
            result.Result.BodyType.Image = result.Result.BodyType.Image.JoinWithCDNAddress();
            return result;
        }
    }
}