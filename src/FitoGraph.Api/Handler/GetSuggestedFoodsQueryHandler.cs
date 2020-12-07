using System;
using System.Data;
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
using FitoGraph.Api.Domain.SP;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class GetSuggestedFoodsQueryHandler : IRequestHandler<GetSuggestedFoodsQuery, ResultWrapper<GetSuggestedFoodsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetSuggestedFoodsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<GetSuggestedFoodsOutput>> Handle(GetSuggestedFoodsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetSuggestedFoodsOutput> result = new ResultWrapper<GetSuggestedFoodsOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                result.Status = false;
                result.Message = "cannot find customer!";
                return Task.FromResult(result);
            }

            var tDataList = _dbContext.SPFindBestFoodsForCustomer(tUser.Id);

            var list = tDataList.Select(tData => new GetSuggestedFoodsOutput.FoodItem()
            {
                Id = tData.Id,
                Title = tData.Title,
                Image = tData.Image.JoinWithCDNAddress(),
                Tags = (tData.Tags ?? string.Empty).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Price = tData.Price,
                MatchRate = tData.MatchRate,
                Restaurant = tData.Restaurant
            })
            .ToList();
            result.Status = true;
            result.Result = new GetSuggestedFoodsOutput()
            {
                list = list
            };

            return Task.FromResult(result);
        }
    }
}