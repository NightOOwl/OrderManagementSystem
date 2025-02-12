using CatalogService.Application.DTOs.CategoryDTOs;
using FluentValidation;

namespace CatalogService.Application.Validations
{
    public class CategoryCreateValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name is too long.");

            RuleFor(x => x.ParentCategoryId)
                .GreaterThan(0).WithMessage("Possitive number expected");
        }

    }
}
