using Microsoft.AspNetCore.Mvc;

namespace Fitograph.Api.Infrastructure
{
    [ApiController]
    [Route("/api/[area]/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}