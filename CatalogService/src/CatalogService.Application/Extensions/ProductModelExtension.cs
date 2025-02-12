using CatalogService.Application.DTOs.ProductDTOs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Extensions
{
    public static class ProductModelExtension
    {
        public static GetProductDto ToGetDto(this Product product)
        {
            return new GetProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Description = product.Description,
                InStock = product.InStock,
            };
        }
    }
}
