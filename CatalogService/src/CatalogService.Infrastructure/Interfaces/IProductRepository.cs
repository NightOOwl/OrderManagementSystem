using CatalogService.Domain.Entities;

namespace CatalogService.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(long productId, Product newProduct, CancellationToken cancellationToken);
        Task<Product> UpdateStockAsync(long productId, int newStock, CancellationToken cancellationToken);
        Task DeleteAsync(long productId, CancellationToken cancellationToken);
        Task<ICollection<Product>> GetPortionAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(long productId, CancellationToken cancellationToken);
        Task<int> GetTotalCountAsync(long categoryId, CancellationToken cancellationToken);
    }
}
