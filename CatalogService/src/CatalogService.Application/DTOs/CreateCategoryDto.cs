using CatalogService.Domain.Entities;

namespace CatalogService.Application.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public long? ParentCategoryId { get; set; }
        public Category ToCategory() => new Category { Name = Name, ParentCategoryId = ParentCategoryId };
    };   
}
