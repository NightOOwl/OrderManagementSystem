using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = productDto.ToProduct();
            await _productService.CreateAsync(product, cancellationToken);
            return Ok(product);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetProductById(long id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);
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
