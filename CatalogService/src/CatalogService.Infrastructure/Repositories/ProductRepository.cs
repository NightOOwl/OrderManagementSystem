using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Interfaces;
using CatalogService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long productId, CancellationToken cancellationToken)
        {
            var productToDelete = await _context.Products.FindAsync(productId, cancellationToken);
            if (productToDelete == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not exists.");
            }

            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(long productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(productId, cancellationToken);
        }

        public async Task<ICollection<Product>> GetPortionAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.CategoryId == categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetTotalCountAsync(long categoryId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.CategoryId == categoryId)
                .CountAsync(cancellationToken);
        }

        public async Task<Product> UpdateAsync(long productId, Product newProduct, CancellationToken cancellationToken)
        {
            var existingProduct = await _context.Products.FindAsync(productId, cancellationToken);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            existingProduct.Name = newProduct.Name;
            existingProduct.Description = newProduct.Description;
            existingProduct.Price = newProduct.Price;
            existingProduct.CategoryId = newProduct.CategoryId;
            existingProduct.InStock = newProduct.InStock;
            existingProduct.UpdateDateUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return existingProduct;
        }

        public async Task<Product> UpdateStockAsync(long productId, int newStock, CancellationToken cancellationToken)
        {
            var existingProduct = await _context.Products.FindAsync(productId, cancellationToken);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            existingProduct.InStock = newStock;
            await _context.SaveChangesAsync(cancellationToken);
            return existingProduct;
        }
    }
}
