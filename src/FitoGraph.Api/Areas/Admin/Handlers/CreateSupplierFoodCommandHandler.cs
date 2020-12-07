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
    public class CreateSupplierFoodCommandHandler : IRequestHandler<CreateSupplierFoodCommand, ResultWrapper<CreateSupplierFoodOutput>>
    {
        private readonly AppDbContext _dbContext;
        public CreateSupplierFoodCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<CreateSupplierFoodOutput>> Handle(CreateSupplierFoodCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CreateSupplierFoodOutput> createFoodResult = new ResultWrapper<CreateSupplierFoodOutput>();
            if (!request.FoodNutritions.Any())
            {
                createFoodResult.Status = false;
                createFoodResult.Message = "please enter nutiritions!";
                return Task.FromResult(createFoodResult);
            }
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    TFood tFood = new TFood()
                    {
                        Title = request.Title,
                        Image = request.Image,
                        Tags = request.Tags,
                        Enabled = request.Enabled,
                        Created = DateTime.Now,
                        TFoodTypeId = request.FoodTypeId,
                        TUserId = request.UserId,
                        TFoodNutritions = new List<TFoodNutrition>(),
                        TReference = new TReference()
                        {
                            Enabled = true,
                            RecordType = ReferenceRecordTypeEnum.FOOD
                        }
                    };
                    _dbContext.TFood.Add(tFood);
                    _dbContext.SaveChanges();
                    tFood.TReference.RecordId = tFood.Id;
                    _dbContext.TReference.Update(tFood.TReference);
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
                        createFoodResult.Status = false;
                        createFoodResult.Message = "Selected diets are invalid!";
                        return Task.FromResult(createFoodResult);
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
                        createFoodResult.Status = false;
                        createFoodResult.Message = "Selected Allergies are invalid!";
                        return Task.FromResult(createFoodResult);
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
                        createFoodResult.Status = false;
                        createFoodResult.Message = "Selected Deficiencies are invalid!";
                        return Task.FromResult(createFoodResult);
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
                        createFoodResult.Status = false;
                        createFoodResult.Message = "Selected nutrition Conditions are invalid!";
                        return Task.FromResult(createFoodResult);
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
                    createFoodResult.Status = true;
                    createFoodResult.Result = new CreateSupplierFoodOutput()
                    {
                        Id = tFood.Id
                    };
                }
            }
            catch (SqlException ex)
            {
                createFoodResult.Status = false;
                createFoodResult.Message = ex.ToJsonString();
            }
            catch (Exception ex)
            {
                createFoodResult.Status = false;
                createFoodResult.Message = ex.ToJsonString();
            }
            return Task.FromResult(createFoodResult);
        }
    }
}