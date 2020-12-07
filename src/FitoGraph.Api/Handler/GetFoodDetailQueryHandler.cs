using System;
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
    public class GetFoodDetailQueryHandler : IRequestHandler<GetFoodDetailQuery, ResultWrapper<GetFoodDetailOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetFoodDetailQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetFoodDetailOutput>> Handle(GetFoodDetailQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetFoodDetailOutput> result = new ResultWrapper<GetFoodDetailOutput>();

            var tData = await _dbContext.TFood
                .Include(x => x.TFoodType)
                .Include(x => x.TReference)
                .Include(x => x.TFoodNutritions).ThenInclude(x => x.TNutrition)
                .Include(x => x.TFoodNutritions).ThenInclude(x => x.TNutritionUnit)
                .FirstOrDefaultAsync(x => x.Id == request.foodId);

            if (tData == null)
            {
                result.Status = false;
                result.Message = "this food doesn't exists";
                return result;
            }
            result.Status = true;
            result.Result = new GetFoodDetailOutput()
            {
                Id = tData.Id,
                Title = tData.Title,
                Image = tData.Image.JoinWithCDNAddress(),
                Enabled = tData.Enabled,
                FoodTypeId = tData.TFoodTypeId,
                FoodTypeName = tData.TFoodType.Title,
                FoodNutritions = tData.TFoodNutritions.Select(x => new GetFoodDetailOutput.FoodNutrition()
                {
                    NutritionId = x.TNutritionId,
                    NutritionName = x.TNutrition.Title,
                    Amount = x.Amount,
                    UnitId = x.TNutritionUnitId,
                    UnitName = x.TNutritionUnit.Title
                }).ToList(),
                VitaminMinreals = new GetFoodDetailOutput.VitaminMinreal()
                {
                    Energy = tData.TReference.Energy,
                    Protein = tData.TReference.Protein,
                    carbohydrate = tData.TReference.carbohydrate,
                    Fat = tData.TReference.Fat,
                    Ash = tData.TReference.Ash,
                    Dietary_Fibre = tData.TReference.Dietary_Fibre,
                    Fructose = tData.TReference.Fructose,
                    Glucose = tData.TReference.Glucose,
                    Sucrose = tData.TReference.Sucrose,
                    Lactose = tData.TReference.Lactose,
                    Total_Sugars = tData.TReference.Total_Sugars,
                    Starch = tData.TReference.Starch,
                    Calcium = tData.TReference.Calcium,
                    Chloride = tData.TReference.Chloride,
                    Copper = tData.TReference.Copper,
                    Fluoride = tData.TReference.Fluoride,
                    Iodine = tData.TReference.Iodine,
                    Iron = tData.TReference.Iron,
                    Magnesium = tData.TReference.Magnesium,
                    Manganese = tData.TReference.Manganese,
                    Phosphorus = tData.TReference.Phosphorus,
                    Potassium = tData.TReference.Potassium,
                    Selenium = tData.TReference.Selenium,
                    Sodium = tData.TReference.Sodium,
                    Sulphur = tData.TReference.Sulphur,
                    Tin = tData.TReference.Tin,
                    Zinc = tData.TReference.Zinc,
                    Alpha_Carotene = tData.TReference.Alpha_Carotene,
                    Beta_Carotene = tData.TReference.Beta_Carotene,
                    Cryptoxanthin = tData.TReference.Cryptoxanthin,
                    Vitamin_A = tData.TReference.Vitamin_A,
                    Lutein = tData.TReference.Lutein,
                    Lycopene = tData.TReference.Lycopene,
                    Thiamin_B1 = tData.TReference.Thiamin_B1,
                    Riboflavin_B2 = tData.TReference.Riboflavin_B2,
                    Niacin_B3 = tData.TReference.Niacin_B3,
                    Pantothenic_Acid_B5 = tData.TReference.Pantothenic_Acid_B5,
                    Vitamin_B6 = tData.TReference.Vitamin_B6,
                    Biotin_B7 = tData.TReference.Biotin_B7,
                    Vitamin_B12 = tData.TReference.Vitamin_B12,
                    Folate = tData.TReference.Folate,
                    Folic_Acid = tData.TReference.Folic_Acid,
                    Vitamin_C = tData.TReference.Vitamin_C,
                    Vitamin_D = tData.TReference.Vitamin_D,
                    Molybdenum = tData.TReference.Molybdenum,
                    Chromium = tData.TReference.Chromium,
                    Vitamin_E = tData.TReference.Vitamin_E,
                    Total_Saturated_Fatty_Acids = tData.TReference.Total_Saturated_Fatty_Acids,
                    Total_Monounsaturated_Fatty_Acids = tData.TReference.Total_Monounsaturated_Fatty_Acids,
                    Total_Polyunsaturated_Fatty_Acids = tData.TReference.Total_Polyunsaturated_Fatty_Acids,
                    Total_Long_Chain_Omega_3_Fatty_Acids = tData.TReference.Total_Long_Chain_Omega_3_Fatty_Acids,
                    Total_Trans_Fatty_Acids = tData.TReference.Total_Trans_Fatty_Acids,
                    Caffeine = tData.TReference.Caffeine,
                    Cholesterol = tData.TReference.Cholesterol,
                }
            };

            return result;
        }
    }
}