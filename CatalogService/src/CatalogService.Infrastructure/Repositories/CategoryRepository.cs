using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Interfaces;
using CatalogService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Category category, CancellationToken cancellationToken)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long categoryId, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _context.Categories.FindAsync(categoryId, cancellationToken);
            if (categoryToDelete == null)
            {
                throw new KeyNotFoundException($"Category with ID {categoryId} not exists.");
            }
            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            var mainCategories = await _context.Categories
                .Where(c => c.ParentCategory == null)
                .Include(c => c.Subcategories)
                .ThenInclude(sc => sc.Subcategories)
                .ToListAsync(cancellationToken);
            return mainCategories;
        }

        public async Task<Category?> GetByIdAsync(long categoryId, CancellationToken cancellationToken)
        {
            return await _context.Categories.FindAsync(categoryId, cancellationToken);
        }

        public Task UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
