using CatalogService.Application.DTOs.ProductDTOs;
using FluentValidation;

namespace CatalogService.Application.Validations
{
    public class ProductCreateValidator : AbstractValidator<CreateProductDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name is too long.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long.");

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.InStock)
                .GreaterThanOrEqualTo(0);

        }
    }
}
