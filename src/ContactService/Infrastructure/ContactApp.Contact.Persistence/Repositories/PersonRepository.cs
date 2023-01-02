using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Domain.Models;
using ContactApp.Contact.Persistence.Context;

namespace ContactApp.Contact.Persistence.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
