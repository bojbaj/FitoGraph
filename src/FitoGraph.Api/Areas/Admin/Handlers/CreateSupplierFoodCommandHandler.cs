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