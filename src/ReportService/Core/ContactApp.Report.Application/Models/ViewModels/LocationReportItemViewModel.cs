namespace ContactApp.Report.Application.Models.ViewModels;

public class LocationReportItemViewModel
{
    public Guid ReportId { get; set; }
    public string Location { get; set; }
    public int RegisteredPersonCount { get; set; }
    public int RegisteredPhoneNumberCount { get; set; }
}