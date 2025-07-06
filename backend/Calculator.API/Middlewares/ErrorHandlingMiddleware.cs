using Calculator.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Calculator.API.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext, ProblemDetailsFactory problemDetailsFactory)
    {
        try
        {
            await next.Invoke(httpContext);
        }
        catch (Exception exception)
        {
            var problemDetails = exception switch
            {
                ValidationException validationException => problemDetailsFactory.CreateFrom(httpContext, validationException),
                DomainException domainException => problemDetailsFactory.CreateFrom(httpContext, domainException),
                _ => problemDetailsFactory.CreateProblemDetails(httpContext, StatusCodes.Status500InternalServerError, "Unhandled error! Please contact us.")
            };

            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, problemDetails.GetType());
        }
    }
}
