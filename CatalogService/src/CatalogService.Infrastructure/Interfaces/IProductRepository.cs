using CatalogService.Domain.Entities;

namespace CatalogService.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(long productId, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken);
        Task<Product?> GetProductByIdAsync(long productId, CancellationToken cancellationToken);
        //Task<int> CountAsync(long categoryId, CancellationToken cancellationToken);
    }
}
