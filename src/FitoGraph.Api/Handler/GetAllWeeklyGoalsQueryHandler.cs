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
    public class GetAllWeeklyGoalsQueryHandler : IRequestHandler<GetAllWeeklyGoalsQuery, ResultWrapper<GetAllWeeklyGoalsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllWeeklyGoalsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllWeeklyGoalsOutput>> Handle(GetAllWeeklyGoalsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllWeeklyGoalsOutput> result = new ResultWrapper<GetAllWeeklyGoalsOutput>();

            GetUserDataRequest getUserDataReq = new GetUserDataRequest()
            {
                idToken = request.idToken
            };

            var tDataList = await _dbContext.TWeeklyGoal
                .Where(x => request.TGoalId == x.TGoalId)
                .ToListAsync();
            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = false,
                Text = x.Title,
                Value = x.Id.ToString(),
                Image = x.Image.JoinWithCDNAddress()
            })
            .ToList();
            result.Status = true;
            result.Result = new GetAllWeeklyGoalsOutput()
            {
                list = list
            };

            return result;
        }
    }
}