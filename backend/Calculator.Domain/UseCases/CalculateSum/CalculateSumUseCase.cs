using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateSum;

internal class CalculateSumUseCase(ICalculateSumService calculateSumService, IValidator<CalculateSumQuery> validator) : ICalculateSumUseCase
{
    public async Task<double> Execute(CalculateSumQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        return calculateSumService.CalculateSum(query.A, query.B);
    }
}
