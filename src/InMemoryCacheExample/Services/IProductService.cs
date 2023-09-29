using DataAccess.Models;

namespace InMemoryCacheExample.Services;

public interface IProductService
{
    Task<List<Product>> GetProducts();
}
