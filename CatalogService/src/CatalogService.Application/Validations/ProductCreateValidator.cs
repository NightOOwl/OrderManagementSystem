using CatalogService.Application.DTOs;
using FluentValidation;

namespace CatalogService.Application.Validations
{
    public class ProductCreateValidator : AbstractValidator<CreateProductDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название продукта обязательно")
                .MaximumLength(100).WithMessage("Название не должно превышать 100 символов");

            RuleFor(x => x.Description)
                .MinimumLength(1000).WithMessage("Описание не должно превышать 1000 символов");

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.InStock)
                .GreaterThanOrEqualTo(0);

        }
    }
}
