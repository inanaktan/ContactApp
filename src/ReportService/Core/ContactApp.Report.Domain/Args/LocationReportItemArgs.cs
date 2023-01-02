namespace ContactApp.Report.Domain.Args;

public class LocationReportItemArgs
{
    public Guid ReportId { get; set; }
    public string Location { get; set; }
    public int RegisteredPersonCount { get; set; }
    public int RegisteredPhoneNumberCount { get; set; }
}
