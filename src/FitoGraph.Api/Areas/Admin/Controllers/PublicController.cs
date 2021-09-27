using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Base;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
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

namespace FitoGraph.Api.Areas.Admin.Controllers
{
    [UserVerification(RoleEnum.Admin)]
    public class PublicController : BaseAdminApiController
    {
        private readonly IMediator _mediator;

        public PublicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("region-countries/{userId?}")]
        public async Task<IActionResult> GetRegionCountries(int userId = 0)
        {
            GetAllRegionCountriesQuery model = new GetAllRegionCountriesQuery()
            {
                userId = userId
            };
            ResultWrapper<GetAllRegionCountriesOutput> result = new ResultWrapper<GetAllRegionCountriesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("region-states/{regionCountryId}/{userId?}")]
        public async Task<IActionResult> GetRegionStates(int regionCountryId, int userId = 0)
        {
            GetRegionStatesQuery model = new GetRegionStatesQuery()
            {
                userId = userId,
                TRegionCountryId = regionCountryId
            };
            ResultWrapper<GetRegionStatesOutput> result = new ResultWrapper<GetRegionStatesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("region-cities/{regionStateId}/{userId?}")]
        public async Task<IActionResult> GetRegionCities(int regionStateId, int userId = 0)
        {
            GetRegionCitiesQuery model = new GetRegionCitiesQuery()
            {
                userId = userId,
                TRegionStateId = regionStateId
            };
            ResultWrapper<GetRegionCitiesOutput> result = new ResultWrapper<GetRegionCitiesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("food-types/{foodId?}")]
        public async Task<IActionResult> GetFoodTypes(int foodId)
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
        [HttpGet("nutrition-units/{nutritionId?}")]
        public async Task<IActionResult> GetNutritionUnits(int nutritionId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllNutritionUnitsQuery model = new GetAllNutritionUnitsQuery()
            {
                firebaseId = user.UserId,
                nutritionId = nutritionId
            };
            ResultWrapper<GetAllNutritionUnitsOutput> result = new ResultWrapper<GetAllNutritionUnitsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("nutritions")]
        public async Task<IActionResult> GetNutritionUnits(int pageSize = 20, int pageNumber = 1, string query = "")
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllNutritionsQuery model = new GetAllNutritionsQuery()
            {
                query = query,
                pageNumber = pageNumber <= 0 ? 1 : pageNumber,
                pageSize = pageSize <= 0 ? 1 : pageSize
            };

            ResultWrapper<GetAllNutritionsOutput> result = new ResultWrapper<GetAllNutritionsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("allergies/{foodId?}")]
        public async Task<IActionResult> GetAllergies(int foodId = 0)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllAllergiesQuery model = new GetAllAllergiesQuery()
            {
                firebaseId = string.Empty,
                foodId = foodId
            };
            ResultWrapper<GetAllAllergiesOutput> result = new ResultWrapper<GetAllAllergiesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("deficiencies/{foodId?}")]
        public async Task<IActionResult> GetDeficiencies(int foodId = 0)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllDeficienciesQuery model = new GetAllDeficienciesQuery()
            {
                firebaseId = string.Empty,
                foodId = foodId
            };
            ResultWrapper<GetAllDeficienciesOutput> result = new ResultWrapper<GetAllDeficienciesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("diets/{foodId?}")]
        public async Task<IActionResult> GetDiets(int foodId = 0)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllDietsQuery model = new GetAllDietsQuery()
            {
                firebaseId = string.Empty,
                foodId = foodId
            };
            ResultWrapper<GetAllDietsOutput> result = new ResultWrapper<GetAllDietsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("nutrition-conditions/{foodId?}")]
        public async Task<IActionResult> GetNutritionConditions(int foodId = 0)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllNutritionConditionsQuery model = new GetAllNutritionConditionsQuery()
            {
                firebaseId = string.Empty,
                foodId = foodId
            };
            ResultWrapper<GetAllNutritionConditionsOutput> result = new ResultWrapper<GetAllNutritionConditionsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("sports/{articleId?}")]
        public async Task<IActionResult> GetSports(int articleId = 0)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllDietsQuery model = new GetAllDietsQuery()
            {
                firebaseId = string.Empty,
                foodId = articleId
            };
            ResultWrapper<GetAllDietsOutput> result = new ResultWrapper<GetAllDietsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}