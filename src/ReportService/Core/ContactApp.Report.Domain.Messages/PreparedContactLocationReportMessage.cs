using ContactApp.Report.Domain.Messages.Models;

namespace ContactApp.Report.Domain.Messages;

public class PreparedContactLocationReportMessage
{
    public Guid ReportId { get; set; }
    public List<LocationReportItem> LocationReportItems { get; set; }
}
