using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FitoGraph.Api.Domain.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Infrastructure
{
    public static class FirebaseExtensions
    {
        public static FirebaseUser GetFirebaseUser(this HttpContext context)
        {
            string tokenHeaderValue = context.Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            string[] tokenValues = (tokenHeaderValue ?? "").Split(' ');
            string token = tokenValues.Length > 1 ? tokenValues[1] : string.Empty;

            Claim cUserId = context.User.Claims.FirstOrDefault(x => x.Type == UserClaimEnum.user_id.ToString());
            string userId = cUserId?.Value ?? string.Empty;

            Claim cEmail = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            string email = cEmail?.Value ?? string.Empty;

            Claim cEmailVerified = context.User.Claims.FirstOrDefault(x => x.Type == UserClaimEnum.email_verified.ToString());
            bool emailverified = Convert.ToBoolean(cEmailVerified?.Value ?? "false");

            FirebaseUser firebaseUser = new FirebaseUser()
            {
                Email = email,
                EmailVerified = emailverified,
                Token = token,
                UserId = userId
            };
            return firebaseUser;
        }

    }
}