using FitoGraph.Api.Areas.Admin.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitoGraph.Api.Areas.Admin.Controllers
{
    public class TestController : BaseAdminApiController
    {
        public TestController()
        {
        }

        [AllowAnonymous]
        [HttpGet("Hi")]
        public IActionResult GetToken()
        {
            return Ok("Hi from Admin");
        }
    }
}