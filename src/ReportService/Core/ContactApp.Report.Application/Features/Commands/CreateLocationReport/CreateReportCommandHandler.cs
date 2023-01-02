using ContactApp.Report.Domain.Abstractions.Repositories;
using ContactApp.Report.Domain.Enums;
using ContactApp.Report.Domain.Events;
using MediatR;

namespace ContactApp.Report.Application.Features.Commands.CreateLocationReport;

public class CreateLocationReportCommandHandler : IRequestHandler<CreateLocationReportCommand, Guid>
{
    private readonly ILocationReportRepository _locationReportepository;
    private readonly IMediator _mediator;

    public CreateLocationReportCommandHandler(ILocationReportRepository locationReportepository, IMediator mediator)
    {
        _locationReportepository = locationReportepository;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(CreateLocationReportCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.LocationReport locationReport = new()
        {
            RequestOn = DateTime.Now,
            Status = LocationReportStatus.Preparing.ToString()
        };
        
        await _locationReportepository.InsertOneAsync(locationReport);

        await PublishReportCreatedEvent(locationReport, cancellationToken);

        return locationReport.Id;
    }

    private Task PublishReportCreatedEvent(Domain.Models.LocationReport report, CancellationToken cancellationToken)
    {
        var createdEvent = new LocationReportCreatedEvent()
        {
            ReportId = report.Id
        };

        return _mediator.Publish(createdEvent, cancellationToken);
    }
}
