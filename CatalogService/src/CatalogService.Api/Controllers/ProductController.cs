using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [ApiController]
    [Route("api/Products")]
    //TODO: добавить DTO для чтения 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public const int PAGE_ITEM_LIMIT = 100; 
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
            var product = await _productService.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(
             [FromQuery] long categoryId, 
             [FromQuery] int page,
             [FromQuery] int pageSize,
             CancellationToken cancellationToken)
        {
            if (pageSize < 0 || page > PAGE_ITEM_LIMIT)
            {
                return BadRequest("pageSize must be in range [0, 100]");
            }
            var products = await _productService.GetAsync(categoryId, page, pageSize, cancellationToken);
            var totalCount = await _productService.GetTotalCountAsync(categoryId, cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var result = new
            {
                products,
                pagination = new
                {
                    count = totalCount,
                    current_page = page,
                    last_page = totalPages
                }
            };

            return Ok(result);
        }

        //[HttpPut("{id:long}")]
        //public async Task<IActionResult> UpdateProduct(long id, [FromBody] Product product, CancellationToken cancellationToken)
        //{
        //    // Метод для обновления продукта
        //}

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteProduct(long id, CancellationToken cancellationToken)
        {
            await _productService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
