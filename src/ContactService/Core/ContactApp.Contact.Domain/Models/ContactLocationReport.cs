namespace ContactApp.Contact.Domain.Models;

public class ContactLocationReport
{
    public Guid ReportId { get; set; }
    public string Location { get; set; }
    public int RegisteredPersonCount { get; set; }
    public int RegisteredPhoneNumberCount { get; set; }
}
