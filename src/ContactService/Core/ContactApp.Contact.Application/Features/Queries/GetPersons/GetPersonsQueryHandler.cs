using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Contact.Application.Features.Queries.GetPersons;

public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonViewModel>>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public GetPersonsQueryHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<List<PersonViewModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        var persons = await _personRepository.GetListAync(p => p.IsDeleted == false);

        var mappedPersons = _mapper.Map<List<PersonViewModel>>(persons);

        return mappedPersons;
    }
}
