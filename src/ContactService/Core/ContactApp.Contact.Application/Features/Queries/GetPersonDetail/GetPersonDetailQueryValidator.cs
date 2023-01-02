using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ContactApp.Contact.Application.Features.Queries.GetPersonDetail;

public class GetPersonDetailQueryValidator : AbstractValidator<GetPersonDetailQuery>
{
    public GetPersonDetailQueryValidator()
    {
        RuleFor(p => p.Id).NotEqual(Guid.Empty);
    }
}
