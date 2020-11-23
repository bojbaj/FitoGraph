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

namespace FitoGraph.Api.Areas.Customer.Handlers
{
    public class GetAllNutritionsQueryHandler : IRequestHandler<GetAllNutritionsQuery, ResultWrapper<GetAllNutritionsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllNutritionsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllNutritionsOutput>> Handle(GetAllNutritionsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllNutritionsOutput> result = new ResultWrapper<GetAllNutritionsOutput>();

            var tDataList = await _dbContext.TNutrition
            .Where(x =>
            string.IsNullOrEmpty(request.query) ||
            x.Code.Contains(request.query) ||
            x.Title.Contains(request.query) ||
            x.TNutritionGroup.Title.Contains(request.query)
            )
            .Skip(request.pageSize * (request.pageNumber - 1))
            .Take(request.pageSize)
            .ToListAsync();

            int totalItems = await _dbContext.TNutrition
                .Where(x =>
                string.IsNullOrEmpty(request.query) ||
                x.Code.Contains(request.query) ||
                x.Title.Contains(request.query) ||
                x.TNutritionGroup.Title.Contains(request.query)
                )
                .CountAsync();

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
            result.Result = new GetAllNutritionsOutput()
            {
                list = list,
                pageSize = request.pageSize,
                pageNumber = request.pageNumber,
                totalItems = totalItems
            };

            return result;
        }
    }
}