using Calculator.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Calculator.API.Middlewares;

public static class ProblemDetailsFactoryExtensions
{
    public static ProblemDetails CreateFrom(this ProblemDetailsFactory factory, HttpContext httpContext, ValidationException validationException)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in validationException.Errors)
        {
            modelStateDictionary.AddModelError(error.PropertyName, error.ErrorCode);
        }

        return factory.CreateValidationProblemDetails(httpContext,
            modelStateDictionary,
            StatusCodes.Status400BadRequest,
            "Validation failed");
    }
    
    public static ProblemDetails CreateFrom(this ProblemDetailsFactory factory, HttpContext httpContext, DomainException domainException) =>
        factory.CreateProblemDetails(httpContext,
            domainException.DomainErrorCode switch
            {
                DomainErrorCode.UnprocessableEntity => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            },
            domainException.Message);
}
