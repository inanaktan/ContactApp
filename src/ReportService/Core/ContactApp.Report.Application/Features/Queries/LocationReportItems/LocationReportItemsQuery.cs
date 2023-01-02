using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Report.Application.Models.ViewModels;
using MediatR;

namespace ContactApp.Report.Application.Features.Queries.LocationReportItems;

public class LocationReportItemsQuery : IRequest<List<LocationReportItemViewModel>>
{
    public Guid ReportId { get; set; }
}
