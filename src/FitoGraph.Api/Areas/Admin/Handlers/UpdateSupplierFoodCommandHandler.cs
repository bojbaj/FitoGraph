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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class UpdateSupplierFoodCommandHandler : IRequestHandler<UpdateSupplierFoodCommand, ResultWrapper<UpdateSupplierFoodOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateSupplierFoodCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<UpdateSupplierFoodOutput>> Handle(UpdateSupplierFoodCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateSupplierFoodOutput> updateFoodResult = new ResultWrapper<UpdateSupplierFoodOutput>();
            if (!request.FoodNutritions.Any())
            {
                updateFoodResult.Status = false;
                updateFoodResult.Message = "please enter nutiritions!";
                return Task.FromResult(updateFoodResult);
            }
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    TFood tFood = _dbContext.TFood
                        .Include(x => x.TFoodNutritions)
                        .FirstOrDefault(x => x.Id == request.Id);

                    if (tFood == null)
                    {
                        updateFoodResult.Status = false;
                        updateFoodResult.Message = "this food doesn't exists!";
                        return Task.FromResult(updateFoodResult);
                    }
                    tFood.Title = request.Title;
                    tFood.Image = request.Image;
                    tFood.Tags = request.Tags;
                    tFood.Price = request.Price;
                    tFood.Enabled = request.Enabled;
                    tFood.TFoodTypeId = request.FoodTypeId;
                    _dbContext.TFood.Update(tFood);
                    _dbContext.SaveChanges();
                    
                    List<TReference> tRefrences = _dbContext.TReference.Where(x => tFood.TFoodNutritions.Select(x => x.TReferenceId).Contains(x.Id)).ToList();
                    _dbContext.TFoodNutrition.RemoveRange(tFood.TFoodNutritions);
                    _dbContext.TReference.RemoveRange(tRefrences);
                    _dbContext.SaveChanges();

                    foreach (var nutrition in request.FoodNutritions)
                    {
                        TFoodNutrition tFoodNutrition = new TFoodNutrition()
                        {
                            Amount = nutrition.Amount,
                            Enabled = true,
                            Created = DateTime.Now,
                            TFoodId = tFood.Id,
                            TNutritionId = nutrition.Id,
                            TNutritionUnitId = nutrition.UnitId,
                            TReference = new TReference()
                            {
                                Enabled = true,
                                RecordType = ReferenceRecordTypeEnum.FOOD_NUTIRTION
                            }
                        };
                        _dbContext.TFoodNutrition.Add(tFoodNutrition);
                    }
                    _dbContext.SaveChanges();

                    foreach (TFoodNutrition foodNutrition in tFood.TFoodNutritions)
                    {
                        foodNutrition.TReference.RecordId = foodNutrition.Id;
                        _dbContext.TReference.Update(foodNutrition.TReference);
                    }
                    _dbContext.SaveChanges();

                    // Food Diets
                    List<TFoodDiet> foodDiets = _dbContext.TFoodDiet.Where(x => x.TFood.Id == tFood.Id).ToList();
                    _dbContext.TFoodDiet.RemoveRange(foodDiets.Where(x => !request.Diets.Contains(x.TDietId)));

                    int selectedDietsCount = _dbContext.TDiet.Where(x => request.Diets.Contains(x.Id)).Count();
                    if (selectedDietsCount != request.Diets.Count)
                    {
                        updateFoodResult.Status = false;
                        updateFoodResult.Message = "Selected diets are invalid!";
                        return Task.FromResult(updateFoodResult);
                    }
                    foreach (int dietId in request.Diets.Where(x => !foodDiets.Any(z => z.TDietId == x)))
                    {
                        _dbContext.TFoodDiet.Add(new TFoodDiet()
                        {
                            TFoodId = tFood.Id,
                            TDietId = dietId
                        });
                    }

                    // Food Allergies
                    List<TFoodAllergy> foodAllergies = _dbContext.TFoodAllergy.Where(x => x.TFood.Id == tFood.Id).ToList();
                    _dbContext.TFoodAllergy.RemoveRange(foodAllergies.Where(x => !request.Allergies.Contains(x.TAllergyId)));

                    int selectedAllergiesCount = _dbContext.TAllergy.Where(x => request.Allergies.Contains(x.Id)).Count();
                    if (selectedAllergiesCount != request.Allergies.Count)
                    {
                        updateFoodResult.Status = false;
                        updateFoodResult.Message = "Selected Allergies are invalid!";
                        return Task.FromResult(updateFoodResult);
                    }
                    foreach (int AllergyId in request.Allergies.Where(x => !foodAllergies.Any(z => z.TAllergyId == x)))
                    {
                        _dbContext.TFoodAllergy.Add(new TFoodAllergy()
                        {
                            TFoodId = tFood.Id,
                            TAllergyId = AllergyId
                        });
                    }

                    // Food Deficiencies
                    List<TFoodDeficiency> foodDeficiencies = _dbContext.TFoodDeficiency.Where(x => x.TFood.Id == tFood.Id).ToList();
                    _dbContext.TFoodDeficiency.RemoveRange(foodDeficiencies.Where(x => !request.Deficiencies.Contains(x.TDeficiencyId)));

                    int selectedDeficienciesCount = _dbContext.TDeficiency.Where(x => request.Deficiencies.Contains(x.Id)).Count();
                    if (selectedDeficienciesCount != request.Deficiencies.Count)
                    {
                        updateFoodResult.Status = false;
                        updateFoodResult.Message = "Selected Deficiencies are invalid!";
                        return Task.FromResult(updateFoodResult);
                    }
                    foreach (int DeficiencyId in request.Deficiencies.Where(x => !foodDeficiencies.Any(z => z.TDeficiencyId == x)))
                    {
                        _dbContext.TFoodDeficiency.Add(new TFoodDeficiency()
                        {
                            TFoodId = tFood.Id,
                            TDeficiencyId = DeficiencyId
                        });
                    }

                    // Food NutritionCondition
                    List<TFoodNutritionCondition> userNutritionConditions = _dbContext.TFoodNutritionCondition.Where(x => x.TFood.Id == tFood.Id).ToList();
                    _dbContext.TFoodNutritionCondition.RemoveRange(userNutritionConditions.Where(x => !request.NutritionConditions.Contains(x.TNutritionConditionId)));

                    int selectedNutritionConditionsCount = _dbContext.TNutritionCondition.Where(x => request.NutritionConditions.Contains(x.Id)).Count();
                    if (selectedNutritionConditionsCount != request.NutritionConditions.Count)
                    {
                        updateFoodResult.Status = false;
                        updateFoodResult.Message = "Selected nutrition Conditions are invalid!";
                        return Task.FromResult(updateFoodResult);
                    }
                    foreach (int NutritionConditionId in request.NutritionConditions.Where(x => !userNutritionConditions.Any(z => z.TNutritionConditionId == x)))
                    {
                        _dbContext.TFoodNutritionCondition.Add(new TFoodNutritionCondition()
                        {
                            TFoodId = tFood.Id,
                            TNutritionConditionId = NutritionConditionId
                        });
                    }
                    _dbContext.SaveChanges();

                    SqlParameter foodId = new SqlParameter("@FoodID", tFood.Id);
                    _dbContext.Database.ExecuteSqlRaw("EXEC spCalculateFoodRefrence @FoodID", foodId);
                    transaction.Complete();
                    updateFoodResult.Status = true;
                    updateFoodResult.Result = new UpdateSupplierFoodOutput()
                    {
                        Id = tFood.Id
                    };
                }
            }
            catch (SqlException ex)
            {
                updateFoodResult.Status = false;
                updateFoodResult.Message = ex.ToJsonString();
            }
            catch (Exception ex)
            {
                updateFoodResult.Status = false;
                updateFoodResult.Message = ex.ToJsonString();
            }
            return Task.FromResult(updateFoodResult);
        }
    }
}