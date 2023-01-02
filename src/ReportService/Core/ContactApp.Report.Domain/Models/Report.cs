using ContactApp.Report.Domain.Abstractions;

namespace ContactApp.Report.Domain.Models;

public class LocationReport : Document
{
    public DateTime RequestOn { get; set; }
    public string Status { get; set; }
}
