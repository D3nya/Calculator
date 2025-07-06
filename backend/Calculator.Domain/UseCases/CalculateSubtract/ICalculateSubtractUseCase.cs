namespace Calculator.Domain.UseCases.CalculateSubtract;

public interface ICalculateSubtractUseCase
{
    Task<double> Execute(CalculateSubtractQuery query, CancellationToken cancellationToken);
}
