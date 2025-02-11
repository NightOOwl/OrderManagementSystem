using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace CatalogService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be null or empty");
            }

            await _productRepository.CreateAsync(product, cancellationToken);
            _logger.LogInformation($"Product with ID {product.Id} successfully created.");
        }

        public async Task DeleteAsync(long productId, CancellationToken cancellationToken)
        {
            try
            {
                await _productRepository.DeleteAsync(productId, cancellationToken);
                _logger.LogInformation($"Product with ID {productId} successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }

        public async Task<Product?> GetByIdAsync(long productId, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(productId, cancellationToken);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {productId} not found.");
            }
            return product;
        }

        public async Task<ICollection<Product>> GetAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetPortionAsync(categoryId, page, pageSize, cancellationToken);
            return products;
        }

        public async Task<int> GetTotalCountAsync(long categoryId, CancellationToken cancellationToken)
        {
            return await _productRepository.GetTotalCountAsync(categoryId, cancellationToken);  
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be null or empty");
            }

            await _productRepository.UpdateAsync(product, cancellationToken);
            _logger.LogInformation($"Product with ID {product.Id} successfully updated.");
        }
    }
}
