using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Base;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
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
    public class AdminsController : BaseAdminApiController
    {
        private readonly IMediator _mediator;

        public AdminsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAdmins()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllAdminsQuery model = new GetAllAdminsQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllAdminsOutput> result = new ResultWrapper<GetAllAdminsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAdmin(DeleteAdminCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.FireBaseId = user.UserId;
            ResultWrapper<DeleteAdminOutput> result = new ResultWrapper<DeleteAdminOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}