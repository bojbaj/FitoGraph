using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Customer.Base;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Domain.Models.User;
using FitoGraph.Api.Events;
using FitoGraph.Api.Filters;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Customer.Controllers
{
    [UserVerification]
    public class PublicController : BaseCustomerApiController
    {
        private readonly IMediator _mediator;

        public PublicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("body-types")]
        public async Task<IActionResult> GetBodyTypes()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllBodyTypesQuery model = new GetAllBodyTypesQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllBodyTypesOutput> result = new ResultWrapper<GetAllBodyTypesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("sports")]
        public async Task<IActionResult> GetSports()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllSportsQuery model = new GetAllSportsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllSportsOutput> result = new ResultWrapper<GetAllSportsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("food-types")]
        public async Task<IActionResult> GetFoodTypes()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllFoodTypesQuery model = new GetAllFoodTypesQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllFoodTypesOutput> result = new ResultWrapper<GetAllFoodTypesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("activity-levels")]
        public async Task<IActionResult> GetActivityLevels()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllActivityLevelsQuery model = new GetAllActivityLevelsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllActivityLevelsOutput> result = new ResultWrapper<GetAllActivityLevelsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("allergies")]
        public async Task<IActionResult> GetAllergies()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllAllergiesQuery model = new GetAllAllergiesQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllAllergiesOutput> result = new ResultWrapper<GetAllAllergiesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("deficiencies")]
        public async Task<IActionResult> GetDeficiencies()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllDeficienciesQuery model = new GetAllDeficienciesQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllDeficienciesOutput> result = new ResultWrapper<GetAllDeficienciesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("diets")]
        public async Task<IActionResult> GetDiets()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllDietsQuery model = new GetAllDietsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllDietsOutput> result = new ResultWrapper<GetAllDietsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("goals")]
        public async Task<IActionResult> GetGoals()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllGoalsQuery model = new GetAllGoalsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllGoalsOutput> result = new ResultWrapper<GetAllGoalsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("weekly-goals/{goalId}")]
        public async Task<IActionResult> GetWeeklyGoals(int goalId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllWeeklyGoalsQuery model = new GetAllWeeklyGoalsQuery()
            {
                firebaseId = user.UserId,
                TGoalId = goalId
            };
            ResultWrapper<GetAllWeeklyGoalsOutput> result = new ResultWrapper<GetAllWeeklyGoalsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("nutrition-conditions")]
        public async Task<IActionResult> GetNutritionConditions()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllNutritionConditionsQuery model = new GetAllNutritionConditionsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllNutritionConditionsOutput> result = new ResultWrapper<GetAllNutritionConditionsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("region-countries")]
        public async Task<IActionResult> GetRegionCountries()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllRegionCountriesQuery model = new GetAllRegionCountriesQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllRegionCountriesOutput> result = new ResultWrapper<GetAllRegionCountriesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("region-states/{regionCountryId}")]
        public async Task<IActionResult> GetRegionStates(int regionCountryId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetRegionStatesQuery model = new GetRegionStatesQuery()
            {
                firebaseId = user.UserId,
                TRegionCountryId = regionCountryId
            };
            ResultWrapper<GetRegionStatesOutput> result = new ResultWrapper<GetRegionStatesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("region-cities/{regionStateId}")]
        public async Task<IActionResult> GetRegionCities(int regionStateId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetRegionCitiesQuery model = new GetRegionCitiesQuery()
            {
                firebaseId = user.UserId,
                TRegionStateId = regionStateId
            };
            ResultWrapper<GetRegionCitiesOutput> result = new ResultWrapper<GetRegionCitiesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}