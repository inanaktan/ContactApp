namespace ContactApp.Report.Domain.Configurations.MongoDbConfigurations;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
}
