using CQRS_Inventary.Models;

namespace CQRS_Inventary.Services
{
    public interface IProductsService
    {
        public Task<IEnumerable<Product>> GetProductListAsync();
        public Task<Product> GetProductByIdAsync(int Id);
        public Task<Product> CreateProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);
    }
}
