using CatalogService.Application.DTOs;
using CatalogService.Application.Extensions;
using CatalogService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [ApiController]
    [Route("/api/Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = categoryDto.ToCategory();
            await _categoryService.CreateAsync(category, cancellationToken);
            return Ok(category.ToGetDto());
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long categoryId, CancellationToken cancellationToken)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Bad ID");
            }
            await _categoryService.DeleteAsync(categoryId, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllAsync(cancellationToken);
            var categoryDtos = categories.Select(category => category.ToGetDto()).ToList();
            return Ok(categoryDtos);
        }

    }
}
