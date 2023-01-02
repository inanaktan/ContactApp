using ContactApp.Contact.Domain.Models;
using MediatR;

namespace ContactApp.Contact.Domain.Events;

public class PreparedContactLocationReportEvent : INotification
{
    public Guid ReportId { get; set; }
    public List<ContactLocationReport> ContactLocationReports { get; set; } = new List<ContactLocationReport>();
}
