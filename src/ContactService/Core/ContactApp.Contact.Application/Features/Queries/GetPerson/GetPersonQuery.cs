using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Contact.Application.Features.GetPerson.Queries;

public class GetPersonQuery : IRequest<PersonViewModel>
{
    public Guid Id { get; set; }
}
