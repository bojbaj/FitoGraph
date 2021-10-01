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
using Stripe;
using Stripe.Checkout;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Commands.Handler
{
    public class CustomerCreatePaymentCommandHandler : IRequestHandler<CustomerCreatePaymentSessionCommand, ResultWrapper<CustomerCreatePaymentSessionOutput>>
    {
        private readonly AppDbContext _dbContext;
        public CustomerCreatePaymentCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<CustomerCreatePaymentSessionOutput>> Handle(CustomerCreatePaymentSessionCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CustomerCreatePaymentSessionOutput> result = new ResultWrapper<CustomerCreatePaymentSessionOutput>();
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

                    string generatedCode = "";
                    string generatedTitle = "";
                    Guid PaymentUniqueId = Guid.NewGuid();

                    TOrder tOrder = new TOrder()
                    {
                        Enabled = true,
                        Code = generatedCode,
                        Created = DateTime.Now,
                        Date = DateTime.Now,
                        Title = generatedTitle,
                        TrackingCode = PaymentUniqueId.ToString(),
                        TSupplierId = tSupplier.Id,
                        TUserId = tUser.Id,
                        TotalPayablePrice = 0,
                        Submited = false
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

                    string SuccessUrl = request.SuccessUrl + "?UID=" + PaymentUniqueId;
                    TPayment tPayment = new TPayment()
                    {
                        UniqueId = PaymentUniqueId,
                        UserId = tUser.Id,
                        Amount = TotalPayablePrice,
                        OrderId = tOrder.Id,
                        Success = false,
                        Used = false,
                        Enabled = true,
                        Created = DateTime.Now,
                    };
                    _dbContext.TPayment.Add(tPayment);
                    _dbContext.SaveChanges();

                    transaction.Complete();

                    string secretKey = "sk_test_51JKejjB9j2pHQUNgVymkcotBwOhw64UhTOxrOWLn6QzpdIqmUOGh0lJCkozGMgWNLYQcg4XKriYmiNjfDRiwujnV00Lv2iKYgC";
                    StripeConfiguration.ApiKey = secretKey;
                    var options = new SessionCreateOptions()
                    {
                        PaymentMethodTypes = new List<String>() { "card" },
                        LineItems = new List<SessionLineItemOptions>() { },
                        PaymentIntentData = new SessionPaymentIntentDataOptions()
                        {
                            ApplicationFeeAmount = 500,
                            TransferData = new SessionPaymentIntentDataTransferDataOptions()
                            {
                                Destination = "acct_1JL9JuPUzKlkrnDH"
                            }
                        },
                        Mode = "payment",
                        SuccessUrl = SuccessUrl,
                        CancelUrl = request.CancelUrl
                    };
                    foreach (var item in request.OrderItems)
                    {
                        options.LineItems.Add(new SessionLineItemOptions()
                        {
                            Quantity = item.Amount,
                            PriceData = new SessionLineItemPriceDataOptions()
                            {
                                Currency = "usd",
                                UnitAmount = item.Price,
                                ProductData = new SessionLineItemPriceDataProductDataOptions()
                                {
                                    Name = item.FoodId.ToString()
                                }
                            }
                        });
                    }
                    var service = new SessionService();
                    Task<Session> session = service.CreateAsync(options);
                    session.Wait();
                    result = new ResultWrapper<CustomerCreatePaymentSessionOutput>()
                    {
                        Status = true,
                        Result = new CustomerCreatePaymentSessionOutput()
                        {
                            SessionId = session.Result.Id,
                            SessionUrl = session.Result.Url
                        }
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