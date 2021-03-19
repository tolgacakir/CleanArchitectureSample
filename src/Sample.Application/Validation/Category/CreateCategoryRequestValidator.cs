using FluentValidation;
using Sample.Application.Categories.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Validation.Category
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .WithMessage("Can not null!")
                .NotEmpty()
                .WithMessage("Can not empty!")
                .MaximumLength(15)
                .WithMessage("Maximum length is 15 charachter");
                
        }
    }
}
