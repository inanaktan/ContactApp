using ContactApp.Contact.Domain.Abstractions;
using ContactApp.Contact.Domain.Enums;

namespace ContactApp.Contact.Domain.Models;

public class Contact : BaseEntity<Guid>
{
    public ContactInformationType InformationType { get; set; }

    public string Content { get; set; }
}
