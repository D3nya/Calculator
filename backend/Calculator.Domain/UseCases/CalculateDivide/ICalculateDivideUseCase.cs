namespace Calculator.Domain.UseCases.CalculateDivide;

public interface ICalculateDivideUseCase
{
    Task<double> Execute(CalculateDivideQuery query, CancellationToken cancellationToken);
}
