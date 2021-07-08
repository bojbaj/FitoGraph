using System.Threading.Tasks;
using FitoGraph.Api.Areas.Supplier.Base;
using FitoGraph.Api.Areas.Supplier.Queries;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Domain.Models.User;
using FitoGraph.Api.Filters;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Supplier.Controllers
{
    [UserVerification(RoleEnum.Supplier)]
    public class OrderController : BaseSupplierApiController
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
            GetSupplierOrdersQuery model = new GetSupplierOrdersQuery()
            {
                firebaseId = user.UserId
            };

            ResultWrapper<GetSupplierOrdersOutput> result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("get/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSupplierOrderDetailQuery model = new GetSupplierOrderDetailQuery()
            {
                firebaseId = user.UserId,
                orderId = orderId
            };
            ResultWrapper<GetSupplierOrderDetailOutput> result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}