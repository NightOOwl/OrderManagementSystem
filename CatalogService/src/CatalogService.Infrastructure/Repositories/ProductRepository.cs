using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Interfaces;
using CatalogService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(long productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(productId, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.CategoryId == categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id, cancellationToken);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
            }

            _context.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
