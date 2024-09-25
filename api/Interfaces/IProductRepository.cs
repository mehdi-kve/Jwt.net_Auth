using api.Dtos.Product;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel, string appUserId);
        Task<Product?> UpdateAsync(int id, UpdateProductDto productModel);
        Task<Product?> DeleteAsync(int id);
    }
}
