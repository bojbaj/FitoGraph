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
    [UserVerification(RoleEnum.Customer)]
    public class FoodsController : BaseCustomerApiController
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetFoods()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSuggestedFoodsQuery model = new GetSuggestedFoodsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetSuggestedFoodsOutput> result = new ResultWrapper<GetSuggestedFoodsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("get/{foodId}")]
        public async Task<IActionResult> GetFood(int foodId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetFoodDetailQuery model = new GetFoodDetailQuery()
            {
                firebaseId = user.UserId,
                foodId = foodId
            };
            ResultWrapper<GetFoodDetailOutput> result = new ResultWrapper<GetFoodDetailOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}