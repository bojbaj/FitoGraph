using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Supplier.Base;
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

namespace FitoGraph.Api.Areas.Supplier.Controllers
{
    [UserVerification(RoleEnum.Supplier)]
    public class SuppliersController : BaseSupplierApiController
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetSuppliers()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllSuppliersQuery model = new GetAllSuppliersQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllSuppliersOutput> result = new ResultWrapper<GetAllSuppliersOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteSupplier(DeleteSupplierCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.FireBaseId = user.UserId;
            ResultWrapper<DeleteSupplierOutput> result = new ResultWrapper<DeleteSupplierOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}