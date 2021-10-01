using System;
using System.Collections.Generic;
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
using Stripe;
using Stripe.Checkout;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Customer.Controllers
{
    [UserVerification(RoleEnum.Customer)]
    public class OrderController : BaseCustomerApiController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetOrders()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetCustomerOrdersQuery model = new GetCustomerOrdersQuery()
            {
                firebaseId = user.UserId
            };

            ResultWrapper<GetCustomerOrdersOutput> result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("get/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetCustomerOrderDetailQuery model = new GetCustomerOrderDetailQuery()
            {
                firebaseId = user.UserId,
                orderId = orderId
            };
            ResultWrapper<GetCustomerOrderDetailOutput> result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("create-payment-session")]
        public async Task<IActionResult> CreatePaymentSession([FromBody] CustomerCreatePaymentSessionCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;

            ResultWrapper<CustomerCreatePaymentSessionOutput> result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitOrder([FromBody] CustomerSubmitOrderCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;
            ResultWrapper<CustomerSubmitOrderOutput> submitResult = await _mediator.Send(model);

            if (!submitResult.Status)
                return Ok(submitResult);

            int orderId = submitResult.Result.Id;
            GetCustomerOrderDetailQuery detailModel = new GetCustomerOrderDetailQuery()
            {
                firebaseId = user.UserId,
                orderId = orderId
            };
            ResultWrapper<GetCustomerOrderDetailOutput> result = await _mediator.Send(detailModel);
            return Ok(result);
        }
    }
}