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

namespace FitoGraph.Api.Areas.Supplier.Handlers
{
    public class GetAllNutritionUnitsQueryHandler : IRequestHandler<GetAllNutritionUnitsQuery, ResultWrapper<GetAllNutritionUnitsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllNutritionUnitsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllNutritionUnitsOutput>> Handle(GetAllNutritionUnitsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllNutritionUnitsOutput> result = new ResultWrapper<GetAllNutritionUnitsOutput>();

            var tDataList = await _dbContext.TNutritionUnit.ToListAsync();
            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = false,
                Text = $"{x.Title} [{x.AmountInGram} gram]",
                Value = x.Id.ToString(),
                Image = string.Empty
            })
            .ToList();
            result.Status = true;
            result.Result = new GetAllNutritionUnitsOutput()
            {
                list = list
            };

            return result;
        }
    }
}