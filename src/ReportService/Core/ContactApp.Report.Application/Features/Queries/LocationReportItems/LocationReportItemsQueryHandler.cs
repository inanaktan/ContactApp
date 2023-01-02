using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Report.Application.Models.ViewModels;
using ContactApp.Report.Domain.Abstractions.Repositories;
using MediatR;

namespace ContactApp.Report.Application.Features.Queries.LocationReportItems;

public class LocationReportItemsQueryHandler : IRequestHandler<LocationReportItemsQuery, List<LocationReportItemViewModel>>
{
    private readonly ILocationReportItemRepository _locationReportItemRepository;
    private readonly IMapper _mapper;

    public LocationReportItemsQueryHandler(ILocationReportItemRepository locationReportItemRepository, IMapper mapper)
    {
        _locationReportItemRepository = locationReportItemRepository;
        _mapper = mapper;
    }

    public Task<List<LocationReportItemViewModel>> Handle(LocationReportItemsQuery request, CancellationToken cancellationToken)
    {
        var items = _locationReportItemRepository.FilterBy(l => l.ReportId == request.ReportId);

        var mappedItems = _mapper.Map<List<LocationReportItemViewModel>>(items);

        return Task.FromResult(mappedItems);
    }
}
