using Microsoft.AspNetCore.Mvc;

namespace FitoGraph.Api.Filters
{
    public class UserVerificationAttribute : TypeFilterAttribute
    {
        public UserVerificationAttribute() : base(typeof(UserVerificationFilter))
        {
            Arguments = new object[] { };
        }
    }
}