using Calculator.Domain.UseCases.CalculateSum;

namespace Calculator.Services.CalculateSum;

internal class CalculateSumService : ICalculateSumService
{
    public double CalculateSum(double a, double b) => a + b;
}
