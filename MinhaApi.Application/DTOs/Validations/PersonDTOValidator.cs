using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Application.DTOs.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("PersonDTOValidator: Name must be passed.");

            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("PersonDTOValidator: Document must be passed.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("PersonDTOValidator: Phone must be passed.");

        }
    }
}
