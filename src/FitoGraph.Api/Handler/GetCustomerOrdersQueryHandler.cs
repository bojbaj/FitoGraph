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
    public class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQuery, ResultWrapper<GetCustomerOrdersOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetCustomerOrdersQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<GetCustomerOrdersOutput>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetCustomerOrdersOutput> result = new ResultWrapper<GetCustomerOrdersOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                result.Status = false;
                result.Message = "cannot find customer!";
                return Task.FromResult(result);
            }

            var list = _dbContext.TOrder
                .Include(x => x.TSupplier)
                .Where(x => x.TUserId == tUser.Id)
                .Where(x => x.Submited)
                .Select(tData => new GetCustomerOrdersOutput.OrderItem()
                {
                    Id = tData.Id,
                    Title = tData.Title,
                    TotalPayablePrice = tData.TotalPayablePrice,
                    Restaurant = tData.TSupplier.RestaurantName,
                    Date = tData.Date
                })
            .ToList();
            result.Status = true;
            result.Result = new GetCustomerOrdersOutput()
            {
                list = list
            };

            return Task.FromResult(result);
        }
    }
}