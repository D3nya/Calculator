namespace Calculator.Domain.UseCases.CalculateSqrt;

public interface ICalculateSqrtUseCase
{
    Task<double> Execute(CalculateSqrtQuery query, CancellationToken cancellationToken);
}
