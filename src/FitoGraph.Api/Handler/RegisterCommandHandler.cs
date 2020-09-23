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

namespace FitoGraph.Api.Commands.Handler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResultWrapper<RegisterOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        public RegisterCommandHandler(IFireBaseTool fireBaseTool)
        {
            _fireBaseTool = fireBaseTool;
        }

        public async Task<ResultWrapper<RegisterOutput>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<RegisterOutput> loginResult = new ResultWrapper<RegisterOutput>();
            SignUpWithEmailAndPasswordRequest singUpReq = new SignUpWithEmailAndPasswordRequest()
            {
                email = request.Username,
                password = request.Password                
            };
            ResultWrapper<SignUpWithEmailAndPasswordResponse> signUpResult = await _fireBaseTool.SignUpWithEmailAndPassword(singUpReq);

            if (!signUpResult.Status)
            {
                loginResult.Status = false;
                loginResult.Message = signUpResult.Message;
                return loginResult;
            }
            loginResult.Status = true;
            loginResult.Result = new RegisterOutput()
            {
                Token = signUpResult.Result.idToken,
                LocalId = signUpResult.Result.localId                
            };

            return loginResult;
        }
    }
}