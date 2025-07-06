using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateSubtract;

internal class CalculateSubtractUseCase(ICalculateSubtractService calculateSubtractService, IValidator<CalculateSubtractQuery> validator) : ICalculateSubtractUseCase
{
    public async Task<double> Execute(CalculateSubtractQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        return calculateSubtractService.CalculateSubtract(query.A, query.B);
    }
}
