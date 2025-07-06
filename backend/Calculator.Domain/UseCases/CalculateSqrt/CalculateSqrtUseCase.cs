using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateSqrt;

internal class CalculateSqrtUseCase(ICalculateSqrtService calculateSqrtService, IValidator<CalculateSqrtQuery> validator) : ICalculateSqrtUseCase
{
    public async Task<double> Execute(CalculateSqrtQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        return calculateSqrtService.CalculateSqrt(query.A, query.B ?? 2);
    }
}
