using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Domain.Enums;

namespace ContactApp.Contact.API.Models.Requests;

public class CreateContactRequestModel
{
    public Guid PersonId { get; set; }
    public ContactInformationType InformationType { get; set; }
    public string Content { get; set; }
}
