using ContactApp.Contact.Domain.Models;
using ContactApp.Contact.Persistence.Context;

namespace ContactApp.Contact.Persistence.Repositories;

public class PersonRepository : Repository<Person, Guid>
{
    public PersonRepository(ContactAppDbContext dbContext) : base(dbContext)
    {
    }
}
