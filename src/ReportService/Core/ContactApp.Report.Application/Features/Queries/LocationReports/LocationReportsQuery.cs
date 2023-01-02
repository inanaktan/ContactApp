using ContactApp.Report.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Report.Application.Features.Queries.LocationReports;

public class LocationReportsQuery : IRequest<List<LocationReportViewModel>>
{
    
}
