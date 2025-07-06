using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateExpression;

internal class CalculateExpressionUseCase(ICalculateExpressionService calculateExpressionService, IValidator<CalculateExpressionQuery> validator) : ICalculateExpressionUseCase
{
    public async Task<double> Execute(CalculateExpressionQuery query, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(query, cancellationToken);
        var cleanedExpression = query.Expression.Replace(" ", string.Empty);
        return calculateExpressionService.CalculateExpression(cleanedExpression);
    }
}
