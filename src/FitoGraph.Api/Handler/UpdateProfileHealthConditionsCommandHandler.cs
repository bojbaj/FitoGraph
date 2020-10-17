using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class UpdateProfileHealthConditionsCommandHandler : IRequestHandler<UpdateProfileHealthConditionsCommand, ResultWrapper<UpdateProfileHealthConditionsOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateProfileHealthConditionsCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<UpdateProfileHealthConditionsOutput>> Handle(UpdateProfileHealthConditionsCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateProfileHealthConditionsOutput> updateProfileResult = new ResultWrapper<UpdateProfileHealthConditionsOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "User doesn't exists";
                return updateProfileResult;
            }

            // User Diets
            List<TUserDiet> userDiets = _dbContext.TUserDiet.Where(x => x.TUser.FireBaseId == request.firebaseId).ToList();
            _dbContext.TUserDiet.RemoveRange(userDiets.Where(x => !request.Diets.Contains(x.TDietId)));

            int selectedDietsCount = _dbContext.TDiet.Where(x => request.Diets.Contains(x.Id)).Count();
            if (selectedDietsCount != request.Diets.Count)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Selected diets are invalid!";
                return updateProfileResult;
            }
            foreach (int dietId in request.Diets.Where(x => !userDiets.Any(z => z.TDietId == x)))
            {
                _dbContext.TUserDiet.Add(new TUserDiet()
                {
                    TUserId = tUser.Id,
                    TDietId = dietId
                });
            }

            // User Allergies
            List<TUserAllergy> userAllergies = _dbContext.TUserAllergy.Where(x => x.TUser.FireBaseId == request.firebaseId).ToList();
            _dbContext.TUserAllergy.RemoveRange(userAllergies.Where(x => !request.Allergies.Contains(x.TAllergyId)));

            int selectedAllergiesCount = _dbContext.TAllergy.Where(x => request.Allergies.Contains(x.Id)).Count();
            if (selectedAllergiesCount != request.Allergies.Count)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Selected Allergies are invalid!";
                return updateProfileResult;
            }
            foreach (int AllergyId in request.Allergies.Where(x => !userAllergies.Any(z => z.TAllergyId == x)))
            {
                _dbContext.TUserAllergy.Add(new TUserAllergy()
                {
                    TUserId = tUser.Id,
                    TAllergyId = AllergyId
                });
            }

            // User Deficiencies
            List<TUserDeficiency> userDeficiencies = _dbContext.TUserDeficiency.Where(x => x.TUser.FireBaseId == request.firebaseId).ToList();
            _dbContext.TUserDeficiency.RemoveRange(userDeficiencies.Where(x => !request.Deficiencies.Contains(x.TDeficiencyId)));

            int selectedDeficienciesCount = _dbContext.TDeficiency.Where(x => request.Deficiencies.Contains(x.Id)).Count();
            if (selectedDeficienciesCount != request.Deficiencies.Count)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Selected Deficiencies are invalid!";
                return updateProfileResult;
            }
            foreach (int DeficiencyId in request.Deficiencies.Where(x => !userDeficiencies.Any(z => z.TDeficiencyId == x)))
            {
                _dbContext.TUserDeficiency.Add(new TUserDeficiency()
                {
                    TUserId = tUser.Id,
                    TDeficiencyId = DeficiencyId
                });
            }

            // User NutritionCondition
            List<TUserNutritionCondition> userNutritionConditions = _dbContext.TUserNutritionCondition.Where(x => x.TUser.FireBaseId == request.firebaseId).ToList();
            _dbContext.TUserNutritionCondition.RemoveRange(userNutritionConditions.Where(x => !request.NutritionConditions.Contains(x.TNutritionConditionId)));

            int selectedNutritionConditionsCount = _dbContext.TNutritionCondition.Where(x => request.NutritionConditions.Contains(x.Id)).Count();
            if (selectedNutritionConditionsCount != request.NutritionConditions.Count)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Selected nutrition Conditions are invalid!";
                return updateProfileResult;
            }
            foreach (int NutritionConditionId in request.NutritionConditions.Where(x => !userNutritionConditions.Any(z => z.TNutritionConditionId == x)))
            {
                _dbContext.TUserNutritionCondition.Add(new TUserNutritionCondition()
                {
                    TUserId = tUser.Id,
                    TNutritionConditionId = NutritionConditionId
                });
            }
            
            int r = await _dbContext.SaveChangesAsync();

            if (r < 0)
            {
                updateProfileResult.Status = false;
                updateProfileResult.Message = "Unhandled error!";
                return updateProfileResult;
            }

            updateProfileResult.Status = true;
            updateProfileResult.Result = new UpdateProfileHealthConditionsOutput()
            {
            };

            return updateProfileResult;
        }
    }
}