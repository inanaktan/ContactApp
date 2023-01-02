using AutoMapper;
using ContactApp.Contact.Application.Features.Commands.CreateContact;
using ContactApp.Contact.Application.Models.ViewModels;
using ContactApp.Contact.Domain.Events;
using ContactApp.Contact.Domain.Models;
using ContactApp.Report.Domain.Messages;

namespace ContactApp.Contact.Application.MappingProfiles;

public class ContactMappings : Profile
{
    public ContactMappings()
    {
        CreateMap<CreateContactCommand, Domain.Models.Contact>();
        CreateMap<Domain.Models.Contact, ContactViewModel>();
        CreateMap<PreparedContactLocationReportEvent, PreparedContactLocationReportMessage>()
                .ForMember(dest => dest.LocationReportItems, opt => opt.MapFrom(src => src.ContactLocationReports));
        CreateMap<ContactLocationReport, ContactApp.Report.Domain.Messages.Models.LocationReportItem>();
    }
}
