using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.API.Models.Errors;
using ContactApp.Contact.API.Models.Requests;
using ContactApp.Contact.Application.Features.Commands.CreateContact;
using ContactApp.Contact.Application.Features.Commands.DeleteContact;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Contact.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(GlobalError), StatusCodes.Status500InternalServerError)]
[ProducesResponseType(typeof(GlobalBadRequestError), StatusCodes.Status400BadRequest)]
public class ContactsController : BaseApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateContactRequestModel request, CancellationToken cancellationToken)
    {
        var command = Mapper.Map<CreateContactCommand>(request);
        var createdContactId = await Mediator.Send(command, cancellationToken);

        return Created(string.Empty, createdContactId);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteContactCommand(){ Id = id };
        await Mediator.Send(command, cancellationToken);

        return NoContent();
    }
}
