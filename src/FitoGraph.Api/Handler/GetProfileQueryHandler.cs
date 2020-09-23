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

            GetUserDataRequest getUserDataReq = new GetUserDataRequest()
            {
                idToken = request.firebaseId
            };

            var tUser = await _dbContext.TUser
                .Include(x => x.TBodyType)
                .Include(x => x.TUserAllergies)
                .Include(x => x.TUserDeficiencies)
                .Include(x => x.TUserDiets)
                .Include(x => x.TUserFoodTypes)
                .Include(x => x.TUserNutritionConditions)
                .Include(x => x.TUserSports)
                .FirstOrDefaultAsync(x => x.FireBaseId == request.firebaseId);
            result.Status = true;
            result.Result = new GetProfileOutput()
            {
                Email = tUser.Email,
                FireBaseId = tUser.FireBaseId,
                Enabled = tUser.Enabled,
                FirstName = tUser.FirstName,
                LastName = tUser.LastName,
                Phone = tUser.Phone,
                BodyType = tUser.TBodyType,
                UserAllergies = tUser.TUserAllergies,
                UserDeficiencies = tUser.TUserDeficiencies,
                UserDiets = tUser.TUserDiets,
                UserFoodTypes = tUser.TUserFoodTypes,
                UserNutritionConditions = tUser.TUserNutritionConditions,
                UserSports = tUser.TUserSports
            };
            return result;
        }
    }
}