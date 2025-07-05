namespace Calculator.Domain.UseCases.CalculateSum;

public interface ICalculateSumUseCase
{
    double Execute(CalculateSumQuery query);
}
