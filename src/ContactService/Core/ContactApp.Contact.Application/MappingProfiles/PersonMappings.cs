using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactApp.Contact.Application.Features.Commands.CreatePerson;
using ContactApp.Contact.Application.Models.ViewModels;
using ContactApp.Contact.Domain.Models;

namespace ContactApp.Contact.Application.MappingProfiles;

public class PersonMappings : Profile
{
    public PersonMappings()
    {
        CreateMap<CreatePersonCommand, Person>();
        CreateMap<Person, PersonViewModel>();
        CreateMap<Person, PersonDetailViewModel>();
    }
}
