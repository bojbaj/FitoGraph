using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Commands.Handler
{
    public class CustomerSubmitOrderCommandHandler : IRequestHandler<CustomerSubmitOrderCommand, ResultWrapper<CustomerSubmitOrderOutput>>
    {
        private readonly AppDbContext _dbContext;
        public CustomerSubmitOrderCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<CustomerSubmitOrderOutput>> Handle(CustomerSubmitOrderCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CustomerSubmitOrderOutput> result = new ResultWrapper<CustomerSubmitOrderOutput>();
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
                    if (tUser == null)
                    {
                        result.Status = false;
                        result.Message = "cannot find customer!";
                        return Task.FromResult(result);
                    }

                    if (!request.OrderItems.Any())
                    {
                        result.Status = false;
                        result.Message = "invalid foods data!";
                        return Task.FromResult(result);
                    }

                    TUser tSupplier = _dbContext.TFood
                        .Include(x => x.TUser)
                        .FirstOrDefault(x => x.Id == request.OrderItems.First().FoodId)?.TUser;
                    if (tSupplier == null)
                    {
                        result.Status = false;
                        result.Message = "cannot find supplier!";
                        return Task.FromResult(result);
                    }

                    TOrder tOrder = _dbContext.TOrder.FirstOrDefault(x => x.TrackingCode == request.Transaction.id);
                    if (tOrder != null)
                    {
                        result.Status = false;
                        result.Message = "Order is duplicated!";
                        return Task.FromResult(result);
                    }

                    string generatedCode = "";
                    string generatedTitle = "";

                    tOrder = new TOrder()
                    {
                        Enabled = true,
                        Code = generatedCode,
                        Created = DateTime.Now,
                        Date = DateTime.Now,
                        Title = generatedTitle,
                        TrackingCode = request.Transaction.id,
                        TSupplierId = tSupplier.Id,
                        TUserId = tUser.Id,
                        TotalPayablePrice = 0
                    };
                    _dbContext.TOrder.Add(tOrder);
                    _dbContext.SaveChanges();

                    decimal TotalPayablePrice = 0;
                    foreach (var detail in request.OrderItems)
                    {
                        TFood food = _dbContext.TFood
                            .FirstOrDefault(x => x.Id == detail.FoodId);

                        if (food == null)
                        {
                            result.Status = false;
                            result.Message = "invalid food data!";
                            return Task.FromResult(result);
                        }
                        TOrderDetail tOrderDetail = new TOrderDetail()
                        {
                            Enabled = true,
                            Created = DateTime.Now,
                            Amount = detail.Amount,
                            TFoodId = food.Id,
                            TUserId = tSupplier.Id,
                            UnitPrice = food.Price,
                            RowPrice = food.Price * detail.Amount,
                            TOrderId = tOrder.Id
                        };
                        TotalPayablePrice += tOrderDetail.RowPrice;
                        _dbContext.TOrderDetail.Add(tOrderDetail);
                    }
                    _dbContext.SaveChanges();

                    tOrder.TotalPayablePrice = TotalPayablePrice;
                    _dbContext.TOrder.Update(tOrder);
                    _dbContext.SaveChanges();

                    transaction.Complete();

                    result.Status = true;
                    result.Result = new CustomerSubmitOrderOutput()
                    {
                        Id = tOrder.Id
                    };
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}