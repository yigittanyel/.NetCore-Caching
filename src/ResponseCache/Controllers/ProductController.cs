using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(CacheProfileName= "Duration10")]
        public IActionResult Get()
        {
            return Ok("Response Cache");
        }
    }
}
