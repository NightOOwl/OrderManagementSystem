using CatalogService.Domain.Entities;

namespace CatalogService.Application.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = default;
        public long CategoryId { get; set; } = default;
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public Product ToProduct()
        {
            return new Product
            {
                Name = Name,
                Description = Description,
                CategoryId = CategoryId,
                Price = Price,
                InStock = InStock,
                CreateDateUtc = DateTime.UtcNow,
                UpdateDateUtc = DateTime.UtcNow,
            };
        }
    }
}
