using ContactApp.Report.Domain.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactApp.Report.Domain.Models;

public class LocationReportItem : Document
{
    public Guid ReportId { get; set; }
    public string Location { get; set; }
    public int RegisteredPersonCount { get; set; }
    public int RegisteredPhoneNumberCount { get; set; }
}
