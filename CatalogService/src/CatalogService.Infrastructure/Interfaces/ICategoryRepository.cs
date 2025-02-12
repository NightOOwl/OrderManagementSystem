using CatalogService.Domain.Entities;

namespace CatalogService.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category, CancellationToken cancellationToken);
        Task UpdateAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(long categoryId, CancellationToken cancellationToken);
        Task<ICollection<Category>> GetAllAsync(CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(long categoryId, CancellationToken cancellationToken);
    }
}
