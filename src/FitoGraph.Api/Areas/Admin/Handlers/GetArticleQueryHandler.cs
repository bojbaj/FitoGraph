using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Helpers.FireBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ResultWrapper<GetArticleOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetArticleQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetArticleOutput>> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetArticleOutput> result = new ResultWrapper<GetArticleOutput>();

            var tData = await _dbContext.TArticle
                .Include(x => x.TArticleSports)
                .ThenInclude(x => x.TSport)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            result.Status = true;
            result.Result = new GetArticleOutput()
            {
                Id = tData.Id,
                Title = tData.Title,
                Summary = tData.Summary,
                Image = tData.Image,
                Enabled = tData.Enabled,
                Content = tData.Content,
                Sports = tData.TArticleSports
                .Select(x => new PublicListItem()
                {
                    Enabled = x.TSport.Enabled,
                    Image = x.TSport.Image,
                    Selected = false,
                    Text = x.TSport.Title,
                    Value = x.TSportId.ToString()
                }).ToList()
            };

            return result;
        }
    }
}