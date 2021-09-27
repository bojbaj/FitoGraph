using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
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
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ResultWrapper<CreateArticleOutput>>
    {
        private readonly AppDbContext _dbContext;
        public CreateArticleCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<CreateArticleOutput>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CreateArticleOutput> createArticleResult = new ResultWrapper<CreateArticleOutput>();
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    TArticle tArticle = new TArticle()
                    {
                        Title = request.Title,
                        Summary = request.Summary,
                        Image = request.Image,
                        Enabled = request.Enabled,
                        Created = DateTime.Now,
                    };
                    _dbContext.TArticle.Add(tArticle);
                    _dbContext.SaveChanges();

                    // Article Sport
                    List<TArticleSport> articleSports = _dbContext.TArticleSport.Where(x => x.TArticle.Id == tArticle.Id).ToList();
                    _dbContext.TArticleSport.RemoveRange(articleSports.Where(x => !request.Sports.Contains(x.TSportId)));

                    int selectedSportsCount = _dbContext.TSport.Where(x => request.Sports.Contains(x.Id)).Count();
                    if (selectedSportsCount != request.Sports.Count)
                    {
                        createArticleResult.Status = false;
                        createArticleResult.Message = "Selected sports are invalid!";
                        return Task.FromResult(createArticleResult);
                    }
                    foreach (int SportId in request.Sports.Where(x => !articleSports.Any(z => z.TSportId == x)))
                    {
                        _dbContext.TArticleSport.Add(new TArticleSport()
                        {
                            TArticleId = tArticle.Id,
                            TSportId = SportId
                        });
                    }
                    _dbContext.SaveChanges();
                    transaction.Complete();
                    createArticleResult.Status = true;
                    createArticleResult.Result = new CreateArticleOutput()
                    {
                        Id = tArticle.Id
                    };
                }
            }
            catch (Exception ex)
            {
                createArticleResult.Status = false;
                createArticleResult.Message = ex.Message;
            }
            return Task.FromResult(createArticleResult);
        }
    }
}