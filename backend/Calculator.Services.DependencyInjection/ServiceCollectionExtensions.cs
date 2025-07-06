using Calculator.Domain.UseCases.CalculateDivide;
using Calculator.Domain.UseCases.CalculateExpression;
using Calculator.Domain.UseCases.CalculateMultiply;
using Calculator.Domain.UseCases.CalculatePow;
using Calculator.Domain.UseCases.CalculateSqrt;
using Calculator.Domain.UseCases.CalculateSubtract;
using Calculator.Domain.UseCases.CalculateSum;
using Calculator.Services.CalculateDivide;
using Calculator.Services.CalculateExpression;
using Calculator.Services.CalculateMultiply;
using Calculator.Services.CalculatePow;
using Calculator.Services.CalculateSqrt;
using Calculator.Services.CalculateSubtract;
using Calculator.Services.CalculateSum;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Services.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCalculatorServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICalculateSumService, CalculateSumService>()
            .AddScoped<ICalculateSubtractService, CalculateSubtractService>()
            .AddScoped<ICalculateMultiplyService, CalculateMultiplyService>()
            .AddScoped<ICalculateDivideService, CalculateDivideService>()
            .AddScoped<ICalculatePowService, CalculatePowService>()
            .AddScoped<ICalculateSqrtService, CalculateSqrtService>()
            .AddScoped<ICalculateExpressionService, CalculateExpressionService>();
        
        return services;
    }
}
