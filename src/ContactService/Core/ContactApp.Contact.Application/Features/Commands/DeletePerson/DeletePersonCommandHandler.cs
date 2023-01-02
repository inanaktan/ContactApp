using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Domain.Models;
using FluentValidation;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.DeletePerson;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPersonRepository _personRepository;

    public DeletePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetAsync(p => p.Id.Equals(request.Id) && p.IsDeleted == false);

        if (person == null)
            throw new ValidationException($"{nameof(Person)} is not found!");

        person.IsDeleted = true;

        await _personRepository.UpdateAsync(person);
        
        return Unit.Value;
    }
}
