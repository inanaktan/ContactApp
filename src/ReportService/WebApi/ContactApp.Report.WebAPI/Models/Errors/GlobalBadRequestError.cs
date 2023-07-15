namespace ContactApp.Report.WebAPI.Models.Errors;

/// <summary>
/// Valdiation Error
/// </summary>
public class GlobalBadRequestError
{
    /// <summary>
    /// Errors
    /// </summary>
    public GlobalBadRequestErrorItem[] Errors { get; set; }

    /// <summary>
    /// Message
    /// </summary>
    public string Message { get; set; }
}

/// <summary>
/// Validation Error Item
/// </summary>
public class GlobalBadRequestErrorItem
{
    /// <summary>
    /// The name of the property
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// The error message
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// The property value that caused the failure
    /// </summary>
    public object AttemptedValue { get; set; }

    /// <summary>
    /// Gets or sets the error code
    /// </summary>
    public string ErrorCode { get; set; }
}