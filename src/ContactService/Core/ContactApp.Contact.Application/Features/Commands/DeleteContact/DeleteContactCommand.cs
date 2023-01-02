using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.DeleteContact;

public class DeleteContactCommand : IRequest
{
    public Guid Id { get; set; }
}
