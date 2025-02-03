using CatalogService.Domain.Entities;

namespace CatalogService.Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = default;
        public Category? Category { get; set; } = default;
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public Product ToProduct()
        {
            return new Product
            {
                Name = Name,
                Description = Description,
                Category = Category,
                Price = Price,
                InStock = InStock,
                CreateDateUtc = DateTime.UtcNow,
                UpdateDateUtc = DateTime.UtcNow,
            };
        }
    }
}
