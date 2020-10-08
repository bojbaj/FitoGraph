using System;
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
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultWrapper<CreateUserOutput>>
    {
        private readonly AppDbContext _dbContext;
        public CreateUserCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<CreateUserOutput>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<CreateUserOutput> createUserResult = new ResultWrapper<CreateUserOutput>();
            try
            {
                TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.Email == request.Email);
                if (tUser == null)
                {
                    tUser = new TUser()
                    { 
                        Email = request.Email,
                        FireBaseId = request.FireBaseId,
                        Enabled = true
                    };
                    _dbContext.TUser.Add(tUser);
                }
                else
                {
                    tUser.FireBaseId = request.FireBaseId;
                }
                await _dbContext.SaveChangesAsync();
                createUserResult.Status = true;
                createUserResult.Result = new CreateUserOutput()
                {
                    Id = tUser.Id,
                    Email = tUser.Email,
                    FireBaseId = tUser.FireBaseId
                };
            }
            catch (Exception ex)
            {
                createUserResult.Status = false;
                createUserResult.Message = ex.Message;
            }
            return createUserResult;
        }
    }
}