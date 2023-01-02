using ContactApp.Report.Domain.Abstractions.Repositories;
using ContactApp.Report.Domain.Configurations.MongoDbConfigurations;

namespace ContactApp.Report.Persistence.Repositories;

public class LocationReportRepository : MongoRepository<Domain.Models.LocationReport>, ILocationReportRepository
{
    public LocationReportRepository(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
    {
        
    }
}
