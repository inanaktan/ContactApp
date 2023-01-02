using ContactApp.Contact.Domain.Abstractions;
using ContactApp.Contact.Domain.Enums;

namespace ContactApp.Contact.Domain.Models;

public class Contact : BaseEntity
{
    public Guid PersonId { get; set; }

    public ContactInformationType InformationType { get; set; }

    public string Content { get; set; }

    public virtual Person Person { get; set; }
}
