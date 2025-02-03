using CSharpFunctionalExtensions;

namespace CatalogService.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = null!;
        public ICollection<Category> Subcategories { get; set; } = new List<Category>();
        public int? ParentCategoryId { get; set; } 
        public Category? ParentCategory { get; set; } 
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
