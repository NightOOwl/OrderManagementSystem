using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(long productId, CancellationToken cancellationToken);
        Task<Product?> GetProductByIdAsync(long productId, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsAsync(long categoryId, int page, int pageSize, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
    }
}
