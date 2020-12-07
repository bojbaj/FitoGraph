using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Supplier.Handlers
{
    public class GetSupplierFoodQueryHandler : IRequestHandler<GetSupplierFoodQuery, ResultWrapper<GetSupplierFoodOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetSupplierFoodQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetSupplierFoodOutput>> Handle(GetSupplierFoodQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetSupplierFoodOutput> result = new ResultWrapper<GetSupplierFoodOutput>();

            var tData = await _dbContext.TFood
                .Include(x => x.TFoodType)
                .Include(x => x.TFoodNutritions).ThenInclude(x => x.TNutrition)
                .Include(x => x.TFoodNutritions).ThenInclude(x => x.TNutritionUnit)
                .FirstOrDefaultAsync(x => x.TUserId == request.SupplierId && x.Id == request.FoodId);
            if (tData == null)
            {
                result.Status = false;
                result.Message = "this food doesn't exists";
                return result;
            }
            result.Status = true;
            result.Result = new GetSupplierFoodOutput()
            {
                Id = tData.Id,
                Title = tData.Title,
                Enabled = tData.Enabled,
                Image = tData.Image.JoinWithCDNAddress(),
                Tags = tData.Tags ?? string.Empty,
                FoodTypeId = tData.TFoodTypeId,
                FoodTypeName = tData.TFoodType.Title,
                FoodNutritions = tData.TFoodNutritions.Select(x => new GetSupplierFoodOutput.FoodNutrition()
                {
                    NutritionId = x.TNutritionId,
                    NutritionName = x.TNutrition.Title,
                    Amount = x.Amount,
                    UnitId = x.TNutritionUnitId,
                    UnitName = x.TNutritionUnit.Title
                })
                .ToList()
            };

            return result;
        }
    }
}