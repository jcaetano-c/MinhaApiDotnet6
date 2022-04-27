using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Application.DTOs.Validations 
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Product CodErp must be passed.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Product Name must be passed.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("Product Price must be passed and bigger than 0.");

        }
    }
}
