using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using ContactApp.Contact.API.Consts;
using ContactApp.Contact.API.Models.Errors;
using FluentValidation;

namespace ContactApp.Contact.API.Middlewares;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
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
        response = new GlobalError(exception.Message);
    }
}