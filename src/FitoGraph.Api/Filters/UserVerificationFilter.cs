using System.Linq;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FitoGraph.Api.Filters
{
    public class UserVerificationFilter : IAuthorizationFilter
    {
        private readonly AppDbContext _dbContext;
        private readonly Infrastructure.AppEnums.RoleEnum _role;
        public UserVerificationFilter(AppDbContext dbContext, AppEnums.RoleEnum role)
        {
            _dbContext = dbContext;
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var firebaseUser = context.HttpContext.GetFirebaseUser();
            bool emailVerifed = firebaseUser.EmailVerified || (new AppEnums.RoleEnum[] { AppEnums.RoleEnum.Admin, AppEnums.RoleEnum.Supplier }.Contains(_role));
            if (firebaseUser == null || !emailVerifed)
            {
                context.Result = new UnauthorizedResult();
            }
            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == firebaseUser.UserId);
            if (tUser == null || tUser.Role != _role)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}