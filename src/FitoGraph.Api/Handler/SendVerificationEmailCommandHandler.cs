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
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Commands.Handler
{
    public class SendVerificationEmailCommandHandler : IRequestHandler<SendVerificationEmailCommand, ResultWrapper<SendVerificationEmailOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        public SendVerificationEmailCommandHandler(IFireBaseTool fireBaseTool)
        {
            _fireBaseTool = fireBaseTool;
        }

        public async Task<ResultWrapper<SendVerificationEmailOutput>> Handle(SendVerificationEmailCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<SendVerificationEmailOutput> verificationResult = new ResultWrapper<SendVerificationEmailOutput>();
            SendVerificationEmailRequest verificationReq = new SendVerificationEmailRequest()
            {
                requestType = FireBaseRequestEnum.VERIFY_EMAIL.ToString(),
                idToken = request.idToken
            };
            ResultWrapper<SendVerificationEmailResponse> verificationEmailResult = await _fireBaseTool.SendEmailVerification(verificationReq);

            if (!verificationEmailResult.Status)
            {
                verificationResult.Status = false;
                verificationResult.Message = verificationEmailResult.Message;
                return verificationResult;
            }
            verificationResult.Status = true;
            verificationResult.Result = new SendVerificationEmailOutput()
            {
                Email = verificationEmailResult.Result.email,
            };

            return verificationResult;
        }
    }
}