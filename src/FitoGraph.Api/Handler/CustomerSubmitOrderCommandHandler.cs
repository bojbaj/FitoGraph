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

                    TOrder tOrder = _dbContext.TOrder.FirstOrDefault(x => x.TrackingCode == request.UID.ToString());
                    if (tOrder != null)
                    {
                        result.Status = false;
                        result.Message = "Order is duplicated!";
                        return Task.FromResult(result);
                    }

                    TPayment TPayment = _dbContext.TPayment
                        .FirstOrDefault(x => x.UniqueId == request.UID && x.UserId == tUser.Id);
                    if (TPayment == null)
                    {
                        result.Status = false;
                        result.Message = "cannot find uid!";
                        return Task.FromResult(result);
                    }
                    if (TPayment.Used)
                    {
                        result.Status = false;
                        result.Message = "already submited!";
                        return Task.FromResult(result);
                    }

                    TPayment.Used = true;
                    _dbContext.TPayment.Update(TPayment);
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