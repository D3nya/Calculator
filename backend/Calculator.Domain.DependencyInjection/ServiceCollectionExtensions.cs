using Calculator.Domain.UseCases.CalculateDivide;
using Calculator.Domain.UseCases.CalculateMultiply;
using Calculator.Domain.UseCases.CalculatePow;
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
            .AddScoped<ICalculateSubtractUseCase, CalculateSubtractUseCase>()
            .AddScoped<ICalculateMultiplyUseCase, CalculateMultiplyUseCase>()
            .AddScoped<ICalculateDivideUseCase, CalculateDivideUseCase>()
            .AddScoped<ICalculatePowUseCase, CalculatePowUseCase>();

        services
            .AddValidatorsFromAssemblyContaining<CalculateSumQueryValidator>();
        
        return services;
    }
}
