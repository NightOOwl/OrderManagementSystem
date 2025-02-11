using CatalogService.Application.Interfaces;
using CatalogService.Application.Services;
using CatalogService.Application.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace CatalogService.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddValidatorsFromAssemblyContaining<ProductCreateValidator>();
            return services;
        }
    }
}
