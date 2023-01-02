using ContactApp.Report.Application.Features.Commands.CreateLocationReport;
using ContactApp.Report.Application.Features.Queries.LocationReports;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Report.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationReportController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var command = new CreateLocationReportCommand();
        var id = await Mediator.Send(command, cancellationToken);
        return Created("", id);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new LocationReportsQuery();
        var reports = await Mediator.Send(query);

        return Ok(reports);
    }
}
