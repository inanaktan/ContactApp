using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Contact.Application.Abstractions;

public interface IContactRepository : IRepository<Domain.Models.Contact>
{
    
}
