using ContactApp.Report.Domain.Args;
using MediatR;

namespace ContactApp.Report.Application.Features.Commands.CompletePreparedReport;

public class CompletePreparedReportCommand : IRequest
{
    public Guid ReportId { get; set; }
    public List<LocationReportItemArgs> LocationReportItems { get; set; }
}
