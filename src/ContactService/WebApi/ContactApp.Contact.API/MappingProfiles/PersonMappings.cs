using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Contact.API.Models.Requests;
using ContactApp.Contact.Application.Features.Commands.CreatePerson;

namespace ContactApp.Contact.API.MappingProfiles;

public class PersonMappings : Profile
{
    public PersonMappings()
    {
        CreateMap<CreatePersonRequestModel, CreatePersonCommand>();
    }
}
