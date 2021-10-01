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

        public async Task<ResultWrapper<CustomerCreatePaymentSessionOutput>> Handle(CustomerCreatePaymentSessionCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CustomerCreatePaymentSessionOutput> result = new ResultWrapper<CustomerCreatePaymentSessionOutput>();
            try
            {
                Guid PaymentUniqueId = Guid.NewGuid();
                string SuccessUrl = request.SuccessUrl + "?UID=" + PaymentUniqueId;

                TUser tUser = await _dbContext.TUser
                    .FirstOrDefaultAsync(x => x.FireBaseId == request.firebaseId);

                if (tUser == null)
                {
                    result.Status = false;
                    result.Message = "User doesn't exists";
                    return result;
                }
                
                TPayment tPayment = new TPayment()
                {
                    UniqueId = PaymentUniqueId,
                    UserId = tUser.Id,
                    Amount = request.OrderItems.Sum(x => x.Price * x.Amount),
                    OrderId = 0,
                    Success = false,
                    Used = false,
                    Enabled = true,
                    Created = DateTime.Now,
                };
                _dbContext.TPayment.Add(tPayment);
                _dbContext.SaveChanges();

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
                Session session = await service.CreateAsync(options);

                result = new ResultWrapper<CustomerCreatePaymentSessionOutput>()
                {
                    Status = true,
                    Result = new CustomerCreatePaymentSessionOutput()
                    {
                        SessionId = session.Id,
                        SessionUrl = session.Url
                    }
                };
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}