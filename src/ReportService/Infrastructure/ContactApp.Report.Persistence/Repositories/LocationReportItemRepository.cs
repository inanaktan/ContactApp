using ContactApp.Report.Domain.Abstractions.Repositories;
using ContactApp.Report.Domain.Configurations.MongoDbConfigurations;

namespace ContactApp.Report.Persistence.Repositories;

public class LocationReportItemRepository : MongoRepository<Domain.Models.LocationReportItem>, ILocationReportItemRepository
{
    public LocationReportItemRepository(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
    {

    }
}
