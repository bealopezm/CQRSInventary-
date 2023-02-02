using CQRS_Inventary.Data;
using CQRS_Inventary.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Inventary.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var removeProduct = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            _context.Products.Remove(removeProduct);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync();
        }
    }
}
