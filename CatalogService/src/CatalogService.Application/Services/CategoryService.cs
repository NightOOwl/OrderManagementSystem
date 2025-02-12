using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace CatalogService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Category category, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name cannot be null or empty");
            }

            await _categoryRepository.CreateAsync(category, cancellationToken);
            _logger.LogInformation($"Category with ID {category.Id} successfully created.");
        }

        public async Task DeleteAsync(long categoryId, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryRepository.DeleteAsync(categoryId, cancellationToken);
                _logger.LogInformation($"Category with ID {categoryId} successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
        }

        public async Task<Category?> GetByIdAsync(long categoryId, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);
            if (category == null)
            {
                _logger.LogWarning($"Category with ID {categoryId} not found.");
            }
            return category;
        }

        public async Task<ICollection<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(cancellationToken);
            return categories;
        }

        //TODO: Add Update method 
        public Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
