using System.Net;
using System.Net.Mime;
using ContactApp.Report.WebAPI.Consts;
using ContactApp.Report.WebAPI.Models.Errors;
using FluentValidation;

namespace ContactApp.Report.WebAPI.Middlewares;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _hostEnvironment;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _hostEnvironment = hostEnvironment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
    {
        object response = null;

        if (exception is ValidationException validationException)
        {
            HandleValidationException(validationException, httpContext, ref response);
        }
        else
        {
            HandleUnknownExceptionType(exception, httpContext, ref response);
        }

        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

        if (response != null)
        {
            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }

    public void HandleValidationException(ValidationException exception, HttpContext httpContext, ref object response)
    {
        var message = !string.IsNullOrWhiteSpace(exception.Message)
                      ? exception.Message
                      : GeneralConsts.BadRequestErrorMessage;

        response = new GlobalBadRequestError
        {
            Message = message,
            Errors = exception.Errors?.Select(p => new GlobalBadRequestErrorItem
            {
                PropertyName = p.PropertyName,
                ErrorMessage = p.ErrorMessage,
                AttemptedValue = p.AttemptedValue,
                ErrorCode = p.ErrorCode
            }).ToArray()
        };

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }

    private void HandleUnknownExceptionType(Exception exception, HttpContext httpContext, ref object response)
    {
        var message = GeneralConsts.UnhandledErrorMessage;

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        if (_hostEnvironment.IsDevelopment())
            response = new GlobalError(exception.Message);
        else
            response = new GlobalError(message);
    }
}