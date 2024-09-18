using testAPI.Dtos.Product;
using testAPI.Helper;
using testAPI.Models;

namespace testAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductDto productModel);
        Task<Product?> DeleteAsync(int id);
    }
}
