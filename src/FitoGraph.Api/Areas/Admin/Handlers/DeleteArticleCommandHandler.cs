using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Helpers.FireBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, ResultWrapper<DeleteArticleOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public DeleteArticleCommandHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<DeleteArticleOutput>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<DeleteArticleOutput> result = new ResultWrapper<DeleteArticleOutput>();
            try
            {
                var tData = await _dbContext.TArticle.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (tData == null)
                {
                    result.Status = false;
                    result.Message = "Article doesn't exists";
                    return result;
                }
                _dbContext.TArticleSport.RemoveRange(tData.TArticleSports);
                _dbContext.TArticle.Remove(tData);
                await _dbContext.SaveChangesAsync();
                result.Status = true;
                result.Result = new DeleteArticleOutput()
                {
                };
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}