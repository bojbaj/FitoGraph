using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Customer.Base;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Events;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace FitoGraph.Api.Areas.Customer.Controllers
{
    public class AccountController : BaseCustomerApiController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] LoginCommand model)
        {
            ResultWrapper<LoginOutput> result = new ResultWrapper<LoginOutput>();
            model.Role = AppEnums.RoleEnum.Customer.ToString();
            result = await _mediator.Send(model);
            if (result.Status)
            {
                CustomerLoggedInEvent opEvent = new CustomerLoggedInEvent()
                {
                    Request = model,
                    Response = result.Result
                };
                await _mediator.Publish(opEvent);
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand model)
        {
            ResultWrapper<RegisterOutput> result = new ResultWrapper<RegisterOutput>();
            model.Role = AppEnums.RoleEnum.Customer.ToString();
            result = await _mediator.Send(model);
            if (result.Status)
            {
                CustomerRegisterEvent opEvent = new CustomerRegisterEvent()
                {
                    Request = model,
                    Response = result.Result
                };
                await _mediator.Publish(opEvent);
            }
            return Ok(result);
        }

        [HttpPost("IsVerified")]
        public async Task<IActionResult> IsVerified()
        {
            string token = Request.Headers[HeaderNames.Authorization].FirstOrDefault().Split(' ')[1];
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user_id").Value;
            string email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            bool emailverified = Convert.ToBoolean(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email_verified").Value);
            VerificationCheckQuery model = new VerificationCheckQuery()
            {
                idToken = token
            };
            ResultWrapper<VerificationCheckOutput> result = new ResultWrapper<VerificationCheckOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}