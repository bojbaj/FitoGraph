using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitoGraph.Api.Infrastructure
{
    [ApiController]
    [EnableCors("ApiCorsPolicy")]
    [Route("/api/[area]/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}