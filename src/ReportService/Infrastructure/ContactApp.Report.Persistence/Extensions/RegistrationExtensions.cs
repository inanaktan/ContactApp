using ContactApp.Report.Domain.Abstractions.Repositories;
using ContactApp.Report.Domain.Configurations.MongoDbConfigurations;
using ContactApp.Report.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContactApp.Report.Persistence.Extensions;

public static class RegistrationExtensions
{
    public static void AddPersistenceRegistrations(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

        serviceCollection.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        
        serviceCollection.AddScoped<ILocationReportRepository, LocationReportRepository>();
        serviceCollection.AddScoped<ILocationReportItemRepository, LocationReportItemRepository>();
    }
}
