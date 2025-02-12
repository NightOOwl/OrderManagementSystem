using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(long categoryId, CancellationToken cancellationToken);
        Task<ICollection<Category>> GetAllAsync(CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(long categoryId, CancellationToken cancellationToken);
        Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken);
    }
}