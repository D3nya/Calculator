namespace Calculator.Domain.UseCases.CalculatePow;

public interface ICalculatePowUseCase
{
    Task<double> Execute(CalculatePowQuery query, CancellationToken cancellationToken);
}
