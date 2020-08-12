using Fitograph.Api.Areas.Supplier.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitograph.Api.Areas.Supplier.Controllers
{
    public class TestController : BaseSupplierApiController
    {
        public TestController()
        {
        }

        [AllowAnonymous]
        [HttpGet("Hi")]
        public IActionResult GetToken()
        {
            return Ok("Hi from supplier");
        }
    }
}