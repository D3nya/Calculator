namespace Calculator.Domain.UseCases.CalculateSum;

internal class CalculateSumUseCase(ICalculateSumService calculateSumService) : ICalculateSumUseCase
{
    public double Execute(CalculateSumQuery query) => 
        calculateSumService.CalculateSum(query.A, query.B);
}
