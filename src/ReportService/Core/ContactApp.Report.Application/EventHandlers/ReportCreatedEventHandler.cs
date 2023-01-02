using ContactApp.Contact.Domain.Message;
using ContactApp.Report.Domain.Events;
using MassTransit;
using MediatR;

namespace ContactApp.Report.Application.EventHandlers;

public class LocationReportCreatedEventHandler : INotificationHandler<LocationReportCreatedEvent>
{
    private readonly IBusControl _busControl;

    public LocationReportCreatedEventHandler(IBusControl busControl)
    {
        _busControl = busControl;
    }

    public async Task Handle(LocationReportCreatedEvent notification, CancellationToken cancellationToken)
    {
        var message = new PrepareLocationReportMessage() { ReportId = notification.ReportId };

        await _busControl.Publish(message, cancellationToken);
    }
}
