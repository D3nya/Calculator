using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateDivide;

internal class CalculateDivideUseCase(ICalculateDivideService calculateDivideService, IValidator<CalculateDivideQuery> validator) : ICalculateDivideUseCase
{
    public async Task<double> Execute(CalculateDivideQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        return calculateDivideService.CalculateDivide(query.A, query.B);
    }
}
