using Calculator.Domain.UseCases.CalculateSubtract;
using Calculator.Domain.UseCases.CalculateSum;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCalculatorDomain(this IServiceCollection services)
    {
        services
            .AddScoped<ICalculateSumUseCase, CalculateSumUseCase>()
            .AddScoped<ICalculateSubtractUseCase, CalculateSubtractUseCase>();

        services
            .AddValidatorsFromAssemblyContaining<CalculateSumQueryValidator>();
        
        return services;
    }
}
