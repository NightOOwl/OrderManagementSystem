using CatalogService.Application.DTOs.CategoryDTOs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Extensions
{
    public static class CategoryModelExtension
    {
        public static GetCategoryDto ToGetDto(this Category category)
        {
            return new GetCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
                SubCategories = category.Subcategories.Select(subcategory => subcategory.ToGetDto()).ToList()
            };
        }
    }
}
