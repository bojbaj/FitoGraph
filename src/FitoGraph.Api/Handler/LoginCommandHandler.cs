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
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private const string BASE_URL = "https://identitytoolkit.googleapis.com/v1/accounts:";

        public LoginCommandHandler(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<ResultWrapper<LoginOutput>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<LoginOutput> result = new ResultWrapper<LoginOutput>()
            {
                Result = new LoginOutput()
            };
            LoginWithEmail loginWithEmail = new LoginWithEmail()
            {
                email = request.Username,
                password = request.Password
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(loginWithEmail), System.Text.Encoding.UTF8, "application/json"); ;
            string action = $"signInWithPassword?key={_appSettings.FireBase.ApiKey}";

            var client = HttpClientManager.GetHttpClientWithProxy(_appSettings.Proxy);
            HttpResponseMessage response = await client.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();
            var loginWithEmailResponse = JsonConvert.DeserializeObject<LoginWithEmailResponse>(strResponse);
            result.Result = new LoginOutput()
            {
                Token = loginWithEmailResponse.idToken
            };
            result.Status = !string.IsNullOrEmpty(result.Result.Token);
            if (!result.Status)
            {
                result.Message = "Username or Password is invalid";
            }
            return result;
        }
    }
}