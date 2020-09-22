using FitoGraph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FitoGraph.Api.Filters
{
    public class UserVerificationFilter : IAuthorizationFilter
    {
        public UserVerificationFilter()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var firebaseUser = context.HttpContext.GetFirebaseUser();
            if (firebaseUser == null || !firebaseUser.EmailVerified)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}