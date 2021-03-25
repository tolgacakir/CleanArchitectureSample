using FluentValidation;
using Sample.Application.Products.Commands.CreateProductWithCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Validation.Product
{
    public class CreateProductWithCategoryRequestValidator : AbstractValidator<CreateProductWithCategoryRequest>
    {
        public CreateProductWithCategoryRequestValidator()
        {
            RuleFor(r => r.CategoryName)
                .NotNull()
                .WithMessage("CategoryName can not be null.")
                .NotEmpty()
                .WithMessage("CategoryName can not be empty")
                .MinimumLength(2)
                .WithMessage("Minimum length is 2 for CategoryName");
        }
    }
}
