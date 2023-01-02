using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Contact.Application.Features.Queries.GetPersonDetail;

public class GetPersonDetailQueryHandler : IRequestHandler<GetPersonDetailQuery, PersonDetailViewModel>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public GetPersonDetailQueryHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<PersonDetailViewModel> Handle(GetPersonDetailQuery request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetAsync(predicate: p => p.Id.Equals(request.Id) && p.IsDeleted == false,
                                                                includes: p => p.Contacts);

        var mapperPerson = _mapper.Map<PersonDetailViewModel>(person);

        return mapperPerson;
    }
}
