using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
using FitoGraph.Api.Areas.Admin.Base;

namespace FitoGraph.Api.Areas.Admin.Controllers
{
    [UserVerification(RoleEnum.Admin)]
    public class CustomersController : BaseAdminApiController
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomers(int pageSize = 20, int pageNumber = 1, string query = "")
        {
            GetAllCustomersQuery model = new GetAllCustomersQuery(){
                query = query,
                pageNumber = pageNumber <= 0 ? 1 : pageNumber,
                pageSize = pageSize <= 0 ? 1 : pageSize
            };            

            ResultWrapper<GetAllCustomersOutput> result = new ResultWrapper<GetAllCustomersOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetCustomerQuery model = new GetCustomerQuery()
            {
                Id = Id
            };
            ResultWrapper<GetCustomerOutput> result = new ResultWrapper<GetCustomerOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.FireBaseId = user.UserId;
            ResultWrapper<DeleteCustomerOutput> result = new ResultWrapper<DeleteCustomerOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}