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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token,
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
                idToken = user.Token
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
                idToken = user.Token
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
                idToken = user.Token,
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
                idToken = user.Token,
                TRegionStateId = regionStateId
            };
            ResultWrapper<GetRegionCitiesOutput> result = new ResultWrapper<GetRegionCitiesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}