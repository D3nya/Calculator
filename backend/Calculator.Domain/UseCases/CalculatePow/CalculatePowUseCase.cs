using FluentValidation;

namespace Calculator.Domain.UseCases.CalculatePow;

internal class CalculatePowUseCase(ICalculatePowService calculatePowService, IValidator<CalculatePowQuery> validator) : ICalculatePowUseCase
{
    public async Task<double> Execute(CalculatePowQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        return calculatePowService.CalculatePow(query.A, query.B);
    }
}
