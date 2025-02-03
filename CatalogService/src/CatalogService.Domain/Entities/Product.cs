using CSharpFunctionalExtensions;
namespace CatalogService.Domain.Entities
{
    public class Product: Entity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = default;
        public long CategoryId {  get; set; }  
        public Category? Category { get; set; } = default;
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public DateTime UpdateDateUtc { get; set; }
    }
}
