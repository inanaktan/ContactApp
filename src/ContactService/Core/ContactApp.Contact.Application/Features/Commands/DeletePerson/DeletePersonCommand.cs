using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.DeletePerson;

public record DeletePersonCommand : IRequest
{
    public Guid Id { get; set; }
}
