using Calculator.Domain.UseCases.CalculateSum;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCalculatorDomain(this IServiceCollection services)
    {
        services
            .AddScoped<ICalculateSumUseCase, CalculateSumUseCase>();
        
        return services;
    }
}
