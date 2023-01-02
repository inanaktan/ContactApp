using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.API.Models.Errors;
using ContactApp.Contact.API.Models.Requests;
using ContactApp.Contact.Application.Features.Commands.CreatePerson;
using ContactApp.Contact.Application.Features.Commands.DeletePerson;
using ContactApp.Contact.Application.Features.GetPerson.Queries;
using ContactApp.Contact.Application.Features.Queries.GetPersonDetail;
using ContactApp.Contact.Application.Features.Queries.GetPersons;
using ContactApp.Contact.Application.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Contact.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(GlobalError), StatusCodes.Status500InternalServerError)]
[ProducesResponseType(typeof(GlobalBadRequestError), StatusCodes.Status400BadRequest)]
public class PersonsController : BaseApiController
{
    [HttpPost] 
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreatePersonRequestModel request, CancellationToken cancellationToken)
    {
        var command = Mapper.Map<CreatePersonCommand>(request);
        var createdPersonId = await Mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Get), new { id = createdPersonId }, createdPersonId);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePersonCommand(){ Id = id };
        await Mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PersonViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var query = new GetPersonsQuery();
        var persons = await Mediator.Send(query);

        if (persons == null)
            return NotFound();
        
        return Ok(persons);
    }

    [HttpGet("{id:guid}/contacts")]
    [ProducesResponseType(typeof(PersonViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonDetail(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetPersonDetailQuery(){ Id = id };
        var person = await Mediator.Send(query, cancellationToken);

        if(person == null)
            return NotFound();

        return Ok(person);
    }
}
