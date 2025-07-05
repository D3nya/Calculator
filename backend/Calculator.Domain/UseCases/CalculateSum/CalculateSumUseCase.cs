namespace Calculator.Domain.UseCases.CalculateSum;

public class CalculateSumUseCase(ICalculateSumService calculateSumService) : ICalculateSumUseCase
{
    public double Execute(CalculateSumQuery query) =>
    calculateSumService.CalculateSum(query.A, query.B);
}
