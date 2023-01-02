using AutoMapper;
using ContactApp.Report.Domain.Abstractions.Repositories;
using ContactApp.Report.Domain.Enums;
using ContactApp.Report.Domain.Models;
using MediatR;

namespace ContactApp.Report.Application.Features.Commands.CompletePreparedReport;

public class CompletePreparedReportCommandHandler : IRequestHandler<CompletePreparedReportCommand>
{
    private readonly ILocationReportRepository _locationReportRepository;
    private readonly ILocationReportItemRepository _locationReportItemRepository;
    private readonly IMapper _mapper;

    public CompletePreparedReportCommandHandler(ILocationReportRepository locationReportRepository, ILocationReportItemRepository locationReportItemRepository, IMapper mapper)
    {
        _locationReportRepository = locationReportRepository;
        _locationReportItemRepository = locationReportItemRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CompletePreparedReportCommand request, CancellationToken cancellationToken)
    {
        var locationReport = await _locationReportRepository.FindByIdAsync(request.ReportId.ToString()) ?? throw new InvalidOperationException($"{nameof(LocationReport)} is not found!");

        if (request.LocationReportItems != null && request.LocationReportItems.Any())
        {
            var locationReportItems = _mapper.Map<List<LocationReportItem>>(request.LocationReportItems);
            await _locationReportItemRepository.InsertManyAsync(locationReportItems);
        }

        locationReport.Status = LocationReportStatus.Completed.ToString();
        await _locationReportRepository.ReplaceOneAsync(locationReport);

        return Unit.Value;
    }
}
