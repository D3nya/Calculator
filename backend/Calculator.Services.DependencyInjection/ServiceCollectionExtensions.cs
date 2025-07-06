using Calculator.Domain.UseCases.CalculateDivide;
using Calculator.Domain.UseCases.CalculateMultiply;
using Calculator.Domain.UseCases.CalculateSubtract;
using Calculator.Domain.UseCases.CalculateSum;
using Calculator.Services.CalculateDivide;
using Calculator.Services.CalculateMultiply;
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
            .AddScoped<ICalculateDivideService, CalculateDivideService>();
        
        return services;
    }
}
