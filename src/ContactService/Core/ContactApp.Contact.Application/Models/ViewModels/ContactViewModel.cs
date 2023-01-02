using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Domain.Enums;

namespace ContactApp.Contact.Application.Models.ViewModels;

public class ContactViewModel
{
    public Guid Id { get; set; }

    public ContactInformationType InformationType { get; set; }

    public string Content { get; set; }
}
