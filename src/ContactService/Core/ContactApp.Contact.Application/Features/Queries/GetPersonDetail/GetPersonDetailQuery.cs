using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Contact.Application.Features.Queries.GetPersonDetail;

public class GetPersonDetailQuery : IRequest<PersonDetailViewModel>
{
    public Guid Id { get; set; }
}
