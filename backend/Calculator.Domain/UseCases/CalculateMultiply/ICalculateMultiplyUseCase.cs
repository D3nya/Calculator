namespace Calculator.Domain.UseCases.CalculateMultiply;

public interface ICalculateMultiplyUseCase
{
    Task<double> Execute(CalculateMultiplyQuery query, CancellationToken cancellationToken);
}
