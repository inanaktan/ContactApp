using AutoMapper;
using ContactApp.Report.Application.Models.ViewModels;
using ContactApp.Report.Domain.Abstractions.Repositories;
using MediatR;

namespace ContactApp.Report.Application.Features.Queries.LocationReports;

public class ReportsQueryHandler : IRequestHandler<LocationReportsQuery, List<LocationReportViewModel>>
{
    private readonly ILocationReportRepository _locationReportRepository;
    private readonly IMapper _mapper;

    public ReportsQueryHandler(ILocationReportRepository locationReportRepository, IMapper mapper)
    {
        _locationReportRepository = locationReportRepository;
        _mapper = mapper;
    }

    public Task<List<LocationReportViewModel>> Handle(LocationReportsQuery request, CancellationToken cancellationToken)
    {
        var reports = _locationReportRepository.AsQueryable().ToList();

        var mappedReports = _mapper.Map<List<LocationReportViewModel>>(reports);

        return Task.FromResult(mappedReports);
    }
}
