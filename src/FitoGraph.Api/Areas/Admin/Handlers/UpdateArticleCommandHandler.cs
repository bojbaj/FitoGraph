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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, ResultWrapper<UpdateArticleOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateArticleCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<UpdateArticleOutput>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateArticleOutput> updateArticleResult = new ResultWrapper<UpdateArticleOutput>();
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    TArticle tArticle = _dbContext.TArticle
                        .Include(x => x.TArticleSports)
                        .FirstOrDefault(x => x.Id == request.Id);

                    if (tArticle == null)
                    {
                        updateArticleResult.Status = false;
                        updateArticleResult.Message = "this Article doesn't exists!";
                        return Task.FromResult(updateArticleResult);
                    }
                    tArticle.Title = request.Title;
                    tArticle.Summary = request.Summary;
                    tArticle.Image = request.Image;
                    tArticle.Content = request.Content;
                    tArticle.Image = request.Image;
                    tArticle.Enabled = request.Enabled;
                    _dbContext.TArticle.Update(tArticle);
                    _dbContext.SaveChanges();

                    // Article Sports
                    List<TArticleSport> ArticleSports = _dbContext.TArticleSport.Where(x => x.TArticle.Id == tArticle.Id).ToList();
                    _dbContext.TArticleSport.RemoveRange(ArticleSports.Where(x => !request.Sports.Contains(x.TSportId)));

                    int selectedSportsCount = _dbContext.TSport.Where(x => request.Sports.Contains(x.Id)).Count();
                    if (selectedSportsCount != request.Sports.Count)
                    {
                        updateArticleResult.Status = false;
                        updateArticleResult.Message = "Selected Sports are invalid!";
                        return Task.FromResult(updateArticleResult);
                    }
                    foreach (int SportId in request.Sports.Where(x => !ArticleSports.Any(z => z.TSportId == x)))
                    {
                        _dbContext.TArticleSport.Add(new TArticleSport()
                        {
                            TArticleId = tArticle.Id,
                            TSportId = SportId
                        });
                    }
                    _dbContext.SaveChanges();

                    transaction.Complete();
                    updateArticleResult.Status = true;
                    updateArticleResult.Result = new UpdateArticleOutput()
                    {
                        Id = tArticle.Id
                    };
                }
            }
            catch (Exception ex)
            {
                updateArticleResult.Status = false;
                updateArticleResult.Message = ex.Message;
            }
            return Task.FromResult(updateArticleResult);
        }
    }
}