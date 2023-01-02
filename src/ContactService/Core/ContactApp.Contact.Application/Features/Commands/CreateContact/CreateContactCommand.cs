using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Domain.Enums;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.CreateContact;

public class CreateContactCommand : IRequest<Guid>
{
    public Guid PersonId { get; set; }
    public ContactInformationType InformationType { get; set; }
    public string Content { get; set; }
}
