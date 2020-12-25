using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Supplier.Outputs;
using FitoGraph.Api.Areas.Supplier.Queries;
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
                .Include(x => x.TFoodAllergies).ThenInclude(x => x.TAllergy)
                .Include(x => x.TFoodDiets).ThenInclude(x => x.TDiet)
                .Include(x => x.TFoodDeficiencies).ThenInclude(x => x.TDeficiency)
                .Include(x => x.TFoodNutritionConditions).ThenInclude(x => x.TNutritionCondition)
                .FirstOrDefaultAsync(x => x.TUser.FireBaseId == request.firebaseId && x.Id == request.FoodId);
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
                Price = tData.Price,
                FoodTypeId = tData.TFoodTypeId,
                FoodTypeName = tData.TFoodType.Title,
                Allergies = tData.TFoodAllergies.Select(x => new PublicListItem()
                {
                    Value = x.TAllergy.Id.ToString(),
                    Text = x.TAllergy.Title,
                    Enabled = x.TAllergy.Enabled,
                    Image = x.TAllergy.Image,
                    Selected = true
                }).ToList(),
                Diets = tData.TFoodDiets.Select(x => new PublicListItem()
                {
                    Value = x.TDiet.ToString(),
                    Text = x.TDiet.Title,
                    Enabled = x.TDiet.Enabled,
                    Image = x.TDiet.Image,
                    Selected = true
                }).ToList(),
                Deficiencies = tData.TFoodDeficiencies.Select(x => new PublicListItem()
                {
                    Value = x.TDeficiency.Id.ToString(),
                    Text = x.TDeficiency.Title,
                    Enabled = x.TDeficiency.Enabled,
                    Image = x.TDeficiency.Image,
                    Selected = true
                }).ToList(),
                NutritionConditions = tData.TFoodNutritionConditions.Select(x => new PublicListItem()
                {
                    Value = x.TNutritionCondition.Id.ToString(),
                    Text = x.TNutritionCondition.Title,
                    Enabled = x.TNutritionCondition.Enabled,
                    Image = x.TNutritionCondition.Image,
                    Selected = true
                }).ToList(),
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