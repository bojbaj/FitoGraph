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

namespace FitoGraph.Api.Areas.Supplier.Controllers
{
    [UserVerification(RoleEnum.Admin)]
    public class SuppliersController : BaseAdminApiController
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

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSupplierQuery model = new GetSupplierQuery()
            {
                firebaseId = user.UserId,
                Id = id
            };
            ResultWrapper<GetSupplierOutput> result = new ResultWrapper<GetSupplierOutput>();
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

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createSupplierCommand)
        {
            ResultWrapper<RegisterOutput> result = new ResultWrapper<RegisterOutput>();
            createSupplierCommand.Role = AppEnums.RoleEnum.Supplier;
            RegisterCommand registerCommand = new RegisterCommand()
            {
                Gender = createSupplierCommand.Gender,
                Username = createSupplierCommand.Email,
                Password = createSupplierCommand.Password,
                Role = createSupplierCommand.Role
            };
            result = await _mediator.Send(registerCommand);

            if (!result.Status)
            {
                return Ok(result);
            }
            AdminRegisterEvent opEvent = new AdminRegisterEvent()
            {
                Request = registerCommand,
                Response = result.Result
            };
            await _mediator.Publish(opEvent);

            createSupplierCommand.FireBaseId = result.Result.LocalId;
            ResultWrapper<CreateSupplierOutput> createSupplierResult = await _mediator.Send(createSupplierCommand);
            return Ok(createSupplierResult);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand updateSupplierCommand)
        {
            ResultWrapper<UpdateSupplierOutput> updateSupplierResult = await _mediator.Send(updateSupplierCommand);
            return Ok(updateSupplierResult);
        }

        [HttpGet("{supplierId}/foods/")]
        public async Task<IActionResult> GetSupplierFoods(int supplierId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSupplierFoodsQuery model = new GetSupplierFoodsQuery()
            {
                firebaseId = user.UserId,
                SupplierId = supplierId
            };
            ResultWrapper<GetSupplierFoodsOutput> result = new ResultWrapper<GetSupplierFoodsOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("{supplierId}/food/{foodId}")]
        public async Task<IActionResult> GetSupplierFood(int supplierId, int foodId)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetSupplierFoodQuery model = new GetSupplierFoodQuery()
            {
                firebaseId = user.UserId,
                SupplierId = supplierId,
                FoodId = foodId
            };
            ResultWrapper<GetSupplierFoodOutput> result = new ResultWrapper<GetSupplierFoodOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

    }
}