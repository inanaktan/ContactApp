using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Contact.Application.Features.GetPerson.Queries;

public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonViewModel>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public GetPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<PersonViewModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetAsync(p => p.Id.Equals(request.Id) && p.IsDeleted == false);

        var mapperPerson = _mapper.Map<PersonViewModel>(person);

        return mapperPerson;
    }
}
