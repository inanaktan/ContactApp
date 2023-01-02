using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ContactApp.Contact.Application.Features.Commands.CreatePerson;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(p => p.FirstName)
                                 .MaximumLength(50);

        RuleFor(p => p.LastName).NotNull()
                                 .NotEmpty()
                                 .Length(1,50);

        RuleFor(p => p.Company).NotNull()
                                 .NotEmpty()
                                 .Length(1, 100);
    }
}
