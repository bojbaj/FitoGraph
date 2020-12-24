using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Supplier.Outputs;
using FitoGraph.Api.Areas.Supplier.Queries;
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
using FitoGraph.Api.Areas.Supplier.Base;

namespace FitoGraph.Api.Areas.Supplier.Controllers
{
    [UserVerification(RoleEnum.Supplier)]
    public class FoodsController : BaseSupplierApiController
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetSupplierFoods()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSupplierFoodsQuery model = new GetSupplierFoodsQuery()
            {
                firebaseId = user.UserId,
            };
            ResultWrapper<GetSupplierFoodsOutput> result = new ResultWrapper<GetSupplierFoodsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("get/{foodId}")]
        public async Task<IActionResult> GetSupplierFood(int foodId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSupplierFoodQuery model = new GetSupplierFoodQuery()
            {
                firebaseId = user.UserId,
                FoodId = foodId
            };
            ResultWrapper<GetSupplierFoodOutput> result = new ResultWrapper<GetSupplierFoodOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }       
    }
}