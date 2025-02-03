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
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Successfully created product with ID {product.Id}");
        }

        public async Task DeleteAsync(long productId, CancellationToken cancellationToken)
        {
            var productToDelete = await _context.Products.FindAsync(productId, cancellationToken);
            if (productToDelete == null)
            {
                _logger.LogWarning($"Product with ID {productId} not found");
                return; 
            }

            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"Successfully deleted product with ID {productId}");
        }

        public async Task<Product?> GetProductByIdAsync(long productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(productId, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.Category.Id == categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
           
            if (await _context.Products.FindAsync(product.Id, cancellationToken) != null)
            {
                _context.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
            }
        }
    }
}
