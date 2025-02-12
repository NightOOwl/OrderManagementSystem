namespace CatalogService.Application.DTOs.CategoryDTOs
{
    public class GetCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? ParentCategoryId { get; set; }
        public ICollection<GetCategoryDto> SubCategories { get; set; } = new List<GetCategoryDto>();
    }
}
