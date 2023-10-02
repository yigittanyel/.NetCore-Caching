using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OutputCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("[action]")]
        [OutputCache(PolicyName = "CacheForTenSeconds")]
        public IEnumerable<Product> GetFiveProduct() // 10 sec waiting time
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Id = index,
                Name = $"Product {index}",
                Price = 100 * index     
            })
            .ToArray();
        }

        [HttpGet("[action]")]
        public ActionResult<string> GetOk(string message) //default 5 sec waiting time
        {
            return message;
        }
    }
}
