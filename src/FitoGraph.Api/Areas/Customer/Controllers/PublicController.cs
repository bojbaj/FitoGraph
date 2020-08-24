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
    }
}