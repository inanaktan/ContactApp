using MediatR;

namespace ContactApp.Report.Domain.Events;

public class LocationReportCreatedEvent : INotification
{
    public Guid ReportId { get; set; }
}
