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
    public class GetArticleDetailQueryHandler : IRequestHandler<GetArticleDetailQuery, ResultWrapper<GetArticleDetailOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetArticleDetailQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetArticleDetailOutput>> Handle(GetArticleDetailQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetArticleDetailOutput> result = new ResultWrapper<GetArticleDetailOutput>();

            List<int> favoriteSports = await _dbContext.TUserSport
                .Include(x => x.TUser)
                .Where(x => x.TUser.FireBaseId == request.firebaseId)
                .Select(x => x.TSportId)
                .ToListAsync();

            var tData = await _dbContext.TArticle
                .Include(x => x.TArticleSports)
                .ThenInclude(x => x.TSport)
                .Where(x =>
                    !favoriteSports.Any() || x.TArticleSports.Any(z => favoriteSports.Contains(z.TSportId))
                )
                .FirstOrDefaultAsync(x => x.Id == request.articleId);

            if (tData == null)
            {
                result.Status = false;
                result.Message = "this article doesn't exists";
                return result;
            }
            result.Status = true;
            result.Result = new GetArticleDetailOutput()
            {
                Id = tData.Id,
                Title = tData.Title,
                Image = tData.Image.JoinWithCDNAddress(),
                Content = tData.Content,
                Enabled = tData.Enabled,
                Summary = tData.Summary,
                Sports = tData.TArticleSports.Select(x => x.TSport.Title).ToList(),
            };

            return result;
        }
    }
}