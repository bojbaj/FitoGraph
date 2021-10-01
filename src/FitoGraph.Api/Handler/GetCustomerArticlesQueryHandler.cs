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
    public class GetCustomerArticlesQueryHandler : IRequestHandler<GetCustomerArticlesQuery, ResultWrapper<GetCustomerArticlesOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetCustomerArticlesQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetCustomerArticlesOutput>> Handle(GetCustomerArticlesQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetCustomerArticlesOutput> result = new ResultWrapper<GetCustomerArticlesOutput>();

            List<int> favoriteSports = await _dbContext.TUserSport
                .Include(x => x.TUser)
                .Where(x => x.TUser.FireBaseId == request.firebaseId)
                .Select(x => x.TSportId)
                .ToListAsync();

            var tDataList = await _dbContext.TArticle
                .Include(x => x.TArticleSports)
                .ThenInclude(x => x.TSport)
                .Where(x => x.Enabled)
                .Where(x =>
                    !favoriteSports.Any() || x.TArticleSports.Any(z => favoriteSports.Contains(z.TSportId))
                )
                .OrderByDescending(x => x.Id)
                .Take(10)
                .ToListAsync();
            var list = tDataList.Select(x => new GetCustomerArticlesOutput.ArticleItem()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                Image = x.Image.JoinWithCDNAddress()
            })
            .ToList();
            result.Status = true;
            result.Result = new GetCustomerArticlesOutput()
            {
                list = list
            };

            return result;
        }
    }
}