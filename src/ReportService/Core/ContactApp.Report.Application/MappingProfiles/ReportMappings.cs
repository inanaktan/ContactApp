using AutoMapper;
using ContactApp.Report.Application.Features.Commands.CompletePreparedReport;
using ContactApp.Report.Application.Models.ViewModels;
using ContactApp.Report.Domain.Args;
using ContactApp.Report.Domain.Messages;
using ContactApp.Report.Domain.Models;

namespace ContactApp.Report.Application.MappingProfiles;

public class ReportMappings : Profile
{
    public ReportMappings()
    {
        CreateMap<Domain.Models.LocationReport, LocationReportViewModel>();
        CreateMap<PreparedContactLocationReportMessage, CompletePreparedReportCommand>()
                    .ForMember(dest => dest.LocationReportItems, opt => opt.MapFrom(src => src.LocationReportItems));
        CreateMap<Domain.Messages.Models.LocationReportItem, LocationReportItemArgs>();
        CreateMap<LocationReportItemArgs, LocationReportItem>();
    }
}
