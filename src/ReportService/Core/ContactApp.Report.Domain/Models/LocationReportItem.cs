using ContactApp.Report.Domain.Abstractions;

namespace ContactApp.Report.Domain.Models;

public class LocationReportItem : Document
{
    public Guid ReportId { get; set; }
    public string Location { get; set; }
    public int RegisteredPersonCount { get; set; }
    public int RegisteredPhoneNumberCount { get; set; }
}
