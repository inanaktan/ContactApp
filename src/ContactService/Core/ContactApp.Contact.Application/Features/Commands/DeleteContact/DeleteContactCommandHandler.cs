using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Abstractions;
using FluentValidation;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.DeleteContact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IContactRepository _contactRepository;

    public DeleteContactCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetAsync(c => c.Id.Equals(request.Id) && c.IsDeleted == false);

        if (contact == null)
            throw new ValidationException($"{nameof(Contact)} is not found!");

        contact.IsDeleted = true;

        await _contactRepository.UpdateAsync(contact);
        
        return Unit.Value;
    }
}
