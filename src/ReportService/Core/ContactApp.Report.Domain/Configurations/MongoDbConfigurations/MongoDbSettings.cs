using MongoDB.Bson;

namespace ContactApp.Report.Domain.Configurations.MongoDbConfigurations;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}
