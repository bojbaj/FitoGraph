using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResultWrapper<LoginOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        public LoginCommandHandler(IFireBaseTool fireBaseTool)
        {
            _fireBaseTool = fireBaseTool;
        }

        public async Task<ResultWrapper<LoginOutput>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<LoginOutput> loginResult = new ResultWrapper<LoginOutput>();
            SignInWithEmailAndPasswordRequest singInReq = new SignInWithEmailAndPasswordRequest()
            {
                email = request.Username,
                password = request.Password
            };
            ResultWrapper<SignInWithEmailAndPasswordResponse> signInResult = await _fireBaseTool.SignInWithEmailAndPassword(singInReq);

            if (!signInResult.Status)
            {
                loginResult.Status = false;
                loginResult.Message = signInResult.Message;
                return loginResult;
            }

            GetUserDataRequest getUserDataReq = new GetUserDataRequest()
            {
                idToken = signInResult.Result.idToken
            };

            ResultWrapper<GetUserDataResponse> getUserDataResult = await _fireBaseTool.GetUserData(getUserDataReq);
            if (!getUserDataResult.Status)
            {
                loginResult.Status = false;
                loginResult.Message = getUserDataResult.Message;
                return loginResult;
            }
            else if (!getUserDataResult.Result.emailVerified)
            {
                loginResult.Status = false;
                loginResult.Message = "account is not verified yet!";
                loginResult.Message = getUserDataResult.ToJsonString();
                return loginResult;
            }

            loginResult.Status = true;
            loginResult.Result = new LoginOutput()
            {
                Token = signInResult.Result.idToken,
                IsVerifed = getUserDataResult.Result.emailVerified
            };

            return loginResult;
        }
    }
}