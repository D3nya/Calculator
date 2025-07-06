using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateMultiply;

namespace Calculator.Services.CalculateMultiply;

internal class CalculateMultiplyService : ICalculateMultiplyService
{
    public double CalculateMultiply(double a, double b)
    {
        var result = a * b;
        
        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        return result;
    }
}
