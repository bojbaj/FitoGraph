using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class VerificationCheckQueryHandler : IRequestHandler<VerificationCheckQuery, ResultWrapper<VerificationCheckOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        public VerificationCheckQueryHandler(IFireBaseTool fireBaseTool)
        {
            _fireBaseTool = fireBaseTool;
        }

        public async Task<ResultWrapper<VerificationCheckOutput>> Handle(VerificationCheckQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<VerificationCheckOutput> verificationCheckResult = new ResultWrapper<VerificationCheckOutput>();

            GetUserDataRequest getUserDataReq = new GetUserDataRequest()
            {
                idToken = request.idToken
            };

            ResultWrapper<GetUserDataResponse> getUserDataResult = await _fireBaseTool.GetUserData(getUserDataReq);
            if (!getUserDataResult.Status)
            {
                verificationCheckResult.Status = false;
                verificationCheckResult.Message = getUserDataResult.Message;
                return verificationCheckResult;
            }

            verificationCheckResult.Status = true;
            verificationCheckResult.Result = new VerificationCheckOutput()
            {
                IsVerifed = getUserDataResult.Result.emailVerified
            };

            return verificationCheckResult;
        }
    }
}