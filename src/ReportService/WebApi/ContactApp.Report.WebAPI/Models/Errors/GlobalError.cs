namespace ContactApp.Report.WebAPI.Models.Errors;

public class GlobalError
{
    public GlobalError(string message)
    {
        this.Message = message;
    }
    
    public string Message { get; set; }
}