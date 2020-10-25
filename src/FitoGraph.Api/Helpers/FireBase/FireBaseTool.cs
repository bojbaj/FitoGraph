using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Helpers.FireBase
{
    public interface IFireBaseTool
    {
        Task<ResultWrapper<SignUpWithEmailAndPasswordResponse>> SignUpWithEmailAndPassword(SignUpWithEmailAndPasswordRequest request);
        Task<ResultWrapper<SignInWithEmailAndPasswordResponse>> SignInWithEmailAndPassword(SignInWithEmailAndPasswordRequest request);
        Task<ResultWrapper<GetUserDataResponse>> GetUserData(GetUserDataRequest request);
        Task<ResultWrapper<SendVerificationEmailResponse>> SendEmailVerification(SendVerificationEmailRequest request);
        Task<ResultWrapper<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request);
        Task<ResultWrapper<DeleteUserResponse>> DeleteUser(DeleteUserRequest request);
    }
    public class FireBaseTool : IFireBaseTool
    {
        private const string BASE_URL = "https://identitytoolkit.googleapis.com/v1/";
        private const string SignUpWithPassword_URL = "accounts:signUp?key=API_KEY";
        private const string SignInWithPassword_URL = "accounts:signInWithPassword?key=API_KEY";
        private const string GetUserData_URL = "accounts:lookup?key=API_KEY";
        private const string SendVerificationEmail_URL = "accounts:sendOobCode?key=API_KEY";
        private const string RefreshToken_URL = "token?key=API_KEY";
        private const string DeleteUser_URL = "accounts:delete?key=API_KEY";

        private readonly HttpClient _httpClient = null;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public FireBaseTool(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _httpClient = HttpClientManager.GetHttpClientWithProxy(_appSettings.Proxy);
        }

        public async Task<ResultWrapper<SignUpWithEmailAndPasswordResponse>> SignUpWithEmailAndPassword(SignUpWithEmailAndPasswordRequest request)
        {
            ResultWrapper<SignUpWithEmailAndPasswordResponse> result = new ResultWrapper<SignUpWithEmailAndPasswordResponse>()
            {
                Result = new SignUpWithEmailAndPasswordResponse()
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"); ;
            string action = SignUpWithPassword_URL.Replace("API_KEY", _appSettings.FireBase.ApiKey);

            HttpResponseMessage response = await _httpClient.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();

            result.Result = JsonConvert.DeserializeObject<SignUpWithEmailAndPasswordResponse>(strResponse);
            result.Status = !string.IsNullOrEmpty(result.Result.idToken);
            if (!result.Status)
            {
                result.Message = result.Result.error.message;
            }
            return result;
        }

        public async Task<ResultWrapper<SignInWithEmailAndPasswordResponse>> SignInWithEmailAndPassword(SignInWithEmailAndPasswordRequest request)
        {
            ResultWrapper<SignInWithEmailAndPasswordResponse> result = new ResultWrapper<SignInWithEmailAndPasswordResponse>()
            {
                Result = new SignInWithEmailAndPasswordResponse()
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"); ;
            string action = SignInWithPassword_URL.Replace("API_KEY", _appSettings.FireBase.ApiKey);

            HttpResponseMessage response = await _httpClient.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();
            result.Result = JsonConvert.DeserializeObject<SignInWithEmailAndPasswordResponse>(strResponse);
            result.Status = !string.IsNullOrEmpty(result.Result.idToken);
            if (!result.Status)
            {
                result.Message = "Username or Password is invalid";
            }
            return result;
        }

        public async Task<ResultWrapper<GetUserDataResponse>> GetUserData(GetUserDataRequest request)
        {
            ResultWrapper<GetUserDataResponse> result = new ResultWrapper<GetUserDataResponse>()
            {
                Result = new GetUserDataResponse()
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"); ;
            string action = GetUserData_URL.Replace("API_KEY", _appSettings.FireBase.ApiKey);

            HttpResponseMessage response = await _httpClient.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();
            GetUserDataResponseWrapper resultWrapper = JsonConvert.DeserializeObject<GetUserDataResponseWrapper>(strResponse);
            resultWrapper.users = resultWrapper.users ?? new List<GetUserDataResponse>() { };
            result.Status = resultWrapper.users.Count > 0;
            if (!result.Status)
            {
                result.Message = "Can't retrive user data";
            }
            result.Result = resultWrapper.users.FirstOrDefault();
            return result;
        }
        public async Task<ResultWrapper<SendVerificationEmailResponse>> SendEmailVerification(SendVerificationEmailRequest request)
        {
            ResultWrapper<SendVerificationEmailResponse> result = new ResultWrapper<SendVerificationEmailResponse>()
            {
                Result = new SendVerificationEmailResponse()
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"); ;
            string action = SendVerificationEmail_URL.Replace("API_KEY", _appSettings.FireBase.ApiKey);

            HttpResponseMessage response = await _httpClient.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();

            result.Result = JsonConvert.DeserializeObject<SendVerificationEmailResponse>(strResponse);
            result.Status = !string.IsNullOrEmpty(result.Result.email);
            if (!result.Status)
            {
                result.Message = result.Result.error.message;
            }
            return result;
        }
        public async Task<ResultWrapper<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request)
        {
            ResultWrapper<RefreshTokenResponse> result = new ResultWrapper<RefreshTokenResponse>()
            {
                Result = new RefreshTokenResponse()
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"); ;
            string action = RefreshToken_URL.Replace("API_KEY", _appSettings.FireBase.ApiKey);

            HttpResponseMessage response = await _httpClient.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();
            result.Result = JsonConvert.DeserializeObject<RefreshTokenResponse>(strResponse);
            result.Status = !string.IsNullOrEmpty(result.Result.id_token);
            if (!result.Status)
            {
                result.Message = "RefreshToken is invalid";
            }
            return result;
        }
        public async Task<ResultWrapper<DeleteUserResponse>> DeleteUser(DeleteUserRequest request)
        {
            ResultWrapper<DeleteUserResponse> result = new ResultWrapper<DeleteUserResponse>()
            {
                Result = new DeleteUserResponse()
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"); ;
            string action = DeleteUser_URL.Replace("API_KEY", _appSettings.FireBase.ApiKey);

            HttpResponseMessage response = await _httpClient.PostAsync(BASE_URL + action, content);

            string strResponse = await response.Content.ReadAsStringAsync();

            result.Result = JsonConvert.DeserializeObject<DeleteUserResponse>(strResponse);
            result.Status = result.Result.error == null;
            if (!result.Status)
            {
                result.Message = result.Result.error.message;
            }
            result.Status = false;
            result.Message = strResponse;
            return result;
        }
    }
}