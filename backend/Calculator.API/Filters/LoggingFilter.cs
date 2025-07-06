using Microsoft.AspNetCore.Mvc.Filters;

namespace Calculator.API.Filters;

public class LoggingFilter(ILogger<LoggingFilter> logger) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        logger.LogInformation("Executing {ActionDescriptorDisplayName}", context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation("Executed {ActionDescriptorDisplayName}", context.ActionDescriptor.DisplayName);
    }
}
