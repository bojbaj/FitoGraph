using System.Threading.Tasks;
using FitoGraph.Api.Areas.Customer.Base;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Events;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}