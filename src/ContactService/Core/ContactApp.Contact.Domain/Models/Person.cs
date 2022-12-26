using ContactApp.Contact.Domain.Abstractions;

namespace ContactApp.Contact.Domain.Models;

public class Person : BaseEntity<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Company { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; }
}
