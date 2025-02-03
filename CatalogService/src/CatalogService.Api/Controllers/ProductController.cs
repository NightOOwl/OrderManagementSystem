using CatalogService.Application.DTOs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = productDto.ToProduct();
            await _productRepository.CreateAsync(product, cancellationToken);
            return Ok(product);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetProductById(long id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(id, cancellationToken);
            return Ok(product);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProducts([FromQuery] long categoryId, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        //{
        //    // Метод для получения списка продуктов
        //}

        //[HttpPut("{id:long}")]
        //public async Task<IActionResult> UpdateProduct(long id, [FromBody] Product product, CancellationToken cancellationToken)
        //{
        //    // Метод для обновления продукта
        //}

        //[HttpDelete("{id:long}")]
        //public async Task<IActionResult> DeleteProduct(long id, CancellationToken cancellationToken)
        //{
        //    // Метод для удаления продукта
        //}
    }
}
