namespace Calculator.Domain.UseCases.CalculateExpression;

public interface ICalculateExpressionUseCase
{
    Task<double> Execute(CalculateExpressionQuery query, CancellationToken cancellationToken);
}
