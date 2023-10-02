using DataAccess.ApplicationDbContext;
using DistributedCache.Services.Cache;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DistributedCache.Services.Product;

public class ProductService : IProductService
{
    private readonly AppDbContext _dbContext;
    private readonly RedisService _redisService;
    public ProductService(AppDbContext dbContext, RedisService redisService)
    {
        _dbContext = dbContext;
        _redisService = redisService;
    }

    public async Task<List<DataAccess.Models.Product>> GetProducts()
    {
        string cacheKey = "productss";

        var redisDb = _redisService.GetDb(0);
        var productsJson = await redisDb.StringGetAsync(cacheKey);

        if (productsJson.HasValue)
        {
            var products = JsonConvert.DeserializeObject<List<DataAccess.Models.Product>>(productsJson);
            return products;
        }
        else
        {
            var products = await _dbContext.Products.ToListAsync();
            await redisDb.StringSetAsync(cacheKey, JsonConvert.SerializeObject(products));

            return products;
        }
    }
}
