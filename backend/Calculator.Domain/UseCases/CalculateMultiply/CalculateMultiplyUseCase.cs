using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateMultiply;

internal class CalculateMultiplyUseCase(ICalculateMultiplyService calculateMultiplyService, IValidator<CalculateMultiplyQuery> validator) : ICalculateMultiplyUseCase
{
    public async Task<double> Execute(CalculateMultiplyQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        return calculateMultiplyService.CalculateMultiply(query.A, query.B);
    }
}
