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
    public class GetAllNutritionConditionsQueryHandler : IRequestHandler<GetAllNutritionConditionsQuery, ResultWrapper<GetAllNutritionConditionsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllNutritionConditionsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllNutritionConditionsOutput>> Handle(GetAllNutritionConditionsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllNutritionConditionsOutput> result = new ResultWrapper<GetAllNutritionConditionsOutput>();

            var tDataList = await _dbContext.TNutritionCondition
                .Include(x => x.TUserNutritionConditions).ThenInclude(x => x.TUser)
                .Include(x => x.TFoodNutritionConditions).ThenInclude(x => x.TFood)
                .ToListAsync();
            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = x.TUserNutritionConditions.Any(z => z.TUser.FireBaseId == request.firebaseId) || x.TFoodNutritionConditions.Any(z => z.TFood.Id == request.foodId),
                Text = x.Title,
                Value = x.Id.ToString(),
                Image = x.Image.JoinWithCDNAddress()
            })
            .ToList();
            result.Status = true;
            result.Result = new GetAllNutritionConditionsOutput()
            {
                list = list
            };

            return result;
        }
    }
}