using Microsoft.AspNetCore.Mvc;

namespace FitoGraph.Api.Filters
{
    public class UserVerificationAttribute : TypeFilterAttribute
    {
        public UserVerificationAttribute(Infrastructure.AppEnums.RoleEnum Role) : base(typeof(UserVerificationFilter))
        {
            Arguments = new object[] { Role };
        }
    }
}