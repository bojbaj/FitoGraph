using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Domain.SP;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class GetCustomerOrderDetailQueryHandler : IRequestHandler<GetCustomerOrderDetailQuery, ResultWrapper<GetCustomerOrderDetailOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetCustomerOrderDetailQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetCustomerOrderDetailOutput>> Handle(GetCustomerOrderDetailQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetCustomerOrderDetailOutput> result = new ResultWrapper<GetCustomerOrderDetailOutput>();


            TUser tUser = await _dbContext.TUser.FirstOrDefaultAsync(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                result.Status = false;
                result.Message = "cannot find customer!";
                return result;
            }

            var tData = await _dbContext.TOrder
                .Include(x => x.TSupplier)
                .Include(x => x.TOrderDetails).ThenInclude(x => x.TFood)
                .FirstOrDefaultAsync(x => x.Id == request.orderId && x.TUserId == tUser.Id);

            if (tData == null)
            {
                result.Status = false;
                result.Message = "this order doesn't exists";
                return result;
            }
            result.Status = true;
            result.Result = new GetCustomerOrderDetailOutput()
            {
                Id = tData.Id,
                Title = tData.Title,
                TotalPayablePrice = tData.TotalPayablePrice,
                Restaurant = tData.TSupplier.RestaurantName,
                Date = tData.Date,
                list = tData.TOrderDetails.Select(x => new GetCustomerOrderDetailOutput.OrderDetailItem()
                {
                    Id = x.Id,
                    FoodId = x.TFoodId,
                    FoodName = x.TFood.Title,
                    Amount = x.Amount,
                    UnitPrice = x.UnitPrice,
                    RowPrice = x.RowPrice
                }).ToList()                
            };

            return result;
        }
    }
}