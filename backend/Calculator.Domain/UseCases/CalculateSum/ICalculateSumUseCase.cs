namespace Calculator.Domain.UseCases.CalculateSum;

public interface ICalculateSumUseCase
{
    Task<double> Execute(CalculateSumQuery query, CancellationToken cancellationToken);
}
