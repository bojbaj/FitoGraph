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
            GetProfileQuery model = new GetProfileQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetProfileOutput> result = new ResultWrapper<GetProfileOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("update-baseinfo")]
        public async Task<IActionResult> UpdateProfileBaseInfo([FromBody] UpdateProfileBaseInfoCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;
            ResultWrapper<UpdateProfileBaseInfoOutput> result = new ResultWrapper<UpdateProfileBaseInfoOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpPost("update-bodyinfo")]
        public async Task<IActionResult> UpdateProfileBodyInfo([FromBody] UpdateProfileBodyInfoCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;
            ResultWrapper<UpdateProfileBodyInfoOutput> result = new ResultWrapper<UpdateProfileBodyInfoOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpPost("update-activities")]
        public async Task<IActionResult> UpdateProfileActivities([FromBody] UpdateProfileActivitiesCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;
            ResultWrapper<UpdateProfileActivitiesOutput> result = new ResultWrapper<UpdateProfileActivitiesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpPost("update-target")]
        public async Task<IActionResult> UpdateProfileTarget([FromBody] UpdateProfileTargetCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;
            ResultWrapper<UpdateProfileTargetOutput> result = new ResultWrapper<UpdateProfileTargetOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("update-health-conditions")]
        public async Task<IActionResult> UpdateProfileHealthConditions([FromBody] UpdateProfileHealthConditionsCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.firebaseId = user.UserId;
            ResultWrapper<UpdateProfileHealthConditionsOutput> result = new ResultWrapper<UpdateProfileHealthConditionsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}