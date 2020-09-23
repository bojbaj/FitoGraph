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
    public class ProfileController : BaseCustomerApiController
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();

            CreateUserCommand createUserCommand = new CreateUserCommand()
            {
                Email = user.Email,
                FireBaseId = user.UserId
            };
            ResultWrapper<CreateUserOutput> createUserResult = await _mediator.Send(createUserCommand);

            GetProfileQuery model = new GetProfileQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetProfileOutput> result = new ResultWrapper<GetProfileOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}