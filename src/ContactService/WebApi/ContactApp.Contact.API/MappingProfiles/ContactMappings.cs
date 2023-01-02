using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Contact.API.Models.Requests;
using ContactApp.Contact.Application.Features.Commands.CreateContact;

namespace ContactApp.Contact.API.MappingProfiles;

public class ContactMappings : Profile
{
    public ContactMappings()
    {
        CreateMap<CreateContactRequestModel, CreateContactCommand>();
    }
}
