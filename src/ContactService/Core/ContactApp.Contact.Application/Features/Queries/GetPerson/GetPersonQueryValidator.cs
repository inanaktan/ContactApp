using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ContactApp.Contact.Application.Features.GetPerson.Queries;

public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
{
    public GetPersonQueryValidator()
    {
        RuleFor(p => p.Id).NotEqual(Guid.Empty);
    }
}
