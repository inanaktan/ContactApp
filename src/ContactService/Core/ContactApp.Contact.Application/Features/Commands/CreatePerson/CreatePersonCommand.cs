using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.CreatePerson;

public class CreatePersonCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
}
