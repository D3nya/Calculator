using Calculator.Domain.UseCases.CalculateSum;

namespace Services.CalculateSum;

public class CalculateSumService : ICalculateSumService
{
    public double CalculateSum(double a, double b) => a + b;
}
