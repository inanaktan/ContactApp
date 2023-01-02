using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Persistence.Context;

namespace ContactApp.Contact.Persistence.Repositories;

public class ContactRepository : Repository<Domain.Models.Contact>, IContactRepository
{
    public ContactRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
