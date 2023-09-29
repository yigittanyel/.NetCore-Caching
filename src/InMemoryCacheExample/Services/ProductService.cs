using DataAccess.ApplicationDbContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCacheExample.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _dbContext;
    private readonly IMemoryCache _cache;

    public ProductService(AppDbContext dbContext, IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    public async Task<List<Product>> GetProducts()
    {
        string cacheKey = "GetProducts";

        if (!_cache.TryGetValue(cacheKey, out List<Product>? products))
        {
            // Önbellekte veri yoksa, DbContext üzerinden veriyi al
            products = await _dbContext.Products.AsNoTracking().ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // 10 dakika boyunca önbellekte kalacak
            };

            _cache.Set(cacheKey, products, cacheEntryOptions);
        }

        return products ?? new List<Product>();
    }
}
