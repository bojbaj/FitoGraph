using Fitograph.Api.Areas.Customer.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitograph.Api.Areas.Customer.Controllers
{
    public class TestController : BaseCustomerApiController
    {
        public TestController()
        {
        }

        [AllowAnonymous]
        [HttpGet("Hi")] 
        public IActionResult GetToken()
        {
            return Ok("Hi from customer");
        }
    }
}