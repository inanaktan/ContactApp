using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Persistence.Context;
using ContactApp.Contact.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactApp.Contact.Persistence.Extensions;

public static class RegistrationExtensions
{
    public static void AddPersistenceRegistrations(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                         options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddScoped<IPersonRepository, PersonRepository>();
        serviceCollection.AddScoped<IContactRepository, ContactRepository>();
    }
}
