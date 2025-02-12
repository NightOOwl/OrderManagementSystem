using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(long productId, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(long productId, CancellationToken cancellationToken);
        Task<ICollection<Product>> GetAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(long productId, Product newProduct, CancellationToken cancellationToken);
        Task<Product> UpdateStockAsync(long productId, int newStock, CancellationToken cancellationToken);
        Task<int> GetTotalCountAsync(long categoryId, CancellationToken cancellationToken);
    }
}
