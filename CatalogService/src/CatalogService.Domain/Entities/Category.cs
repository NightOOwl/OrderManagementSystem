using CSharpFunctionalExtensions;

namespace CatalogService.Domain.Entities
{
    public class Category : Entity
    {
        private Category()
        {
            
        }
        public string Name { get; set; } = null!;
        public IEnumerable<Category>? Subcategories { get; set; } = default;
        public Category? ParentCategory { get; set; } = default;
        public IEnumerable<Product>? Products = default;
    }
}
