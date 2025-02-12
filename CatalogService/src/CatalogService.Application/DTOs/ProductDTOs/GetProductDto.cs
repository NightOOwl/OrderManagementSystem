namespace CatalogService.Application.DTOs.ProductDTOs
{
    public class GetProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public bool IsAvailable { get=> InStock > 0;} 
    }
}
