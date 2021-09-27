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
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, ResultWrapper<GetAllArticlesOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllArticlesQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllArticlesOutput>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllArticlesOutput> result = new ResultWrapper<GetAllArticlesOutput>();

            var tDataList = await _dbContext.TArticle.ToListAsync();
            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = false,
                Text = x.Title,
                Value = x.Id.ToString(),
                Image = string.Empty
            })
            .ToList();
            result.Status = true;
            result.Result = new GetAllArticlesOutput()
            {
                list = list
            };

            return result;
        }
    }
}