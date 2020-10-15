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
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ResultWrapper<RefreshTokenOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        public RefreshTokenCommandHandler(IFireBaseTool fireBaseTool)
        {
            _fireBaseTool = fireBaseTool;
        }

        public async Task<ResultWrapper<RefreshTokenOutput>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<RefreshTokenOutput> refreshTokenOutput = new ResultWrapper<RefreshTokenOutput>();
            RefreshTokenRequest refreshTokenReq = new RefreshTokenRequest()
            {
                refresh_token = request.RefreshToken,
                grant_type = AppEnums.FireBaseRequestEnum.refresh_token.ToString(),
            };
            ResultWrapper<RefreshTokenResponse> refreshTokenResult = await _fireBaseTool.RefreshToken(refreshTokenReq);

            if (!refreshTokenResult.Status)
            {
                refreshTokenOutput.Status = false;
                refreshTokenOutput.Message = refreshTokenResult.Message;
                return refreshTokenOutput;
            }

            refreshTokenOutput.Status = true;
            refreshTokenOutput.Result = new RefreshTokenOutput()
            {
                Token = refreshTokenResult.Result.id_token,
                RefreshToken = refreshTokenResult.Result.refresh_token
            };

            return refreshTokenOutput;
        }
    }
}