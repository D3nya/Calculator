using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateSum;

namespace Calculator.Services.CalculateSum;

internal class CalculateSumService : ICalculateSumService
{
    public double CalculateSum(double a, double b)
    {
        var result = a + b;

        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        return result;
    }
}
