using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.PrepareLocationReport;

public class PrepareContactLocationReportCommand : IRequest
{
    public Guid ReportId { get; set; }
}
