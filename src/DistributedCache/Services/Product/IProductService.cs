using DataAccess.Models;

namespace DistributedCache.Services.Product;

public interface IProductService
{
    Task<List<DataAccess.Models.Product>> GetProducts();
}