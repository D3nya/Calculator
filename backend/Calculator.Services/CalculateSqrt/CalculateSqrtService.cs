using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateSqrt;

namespace Calculator.Services.CalculateSqrt;

internal class CalculateSqrtService :  ICalculateSqrtService
{
    public double CalculateSqrt(double a, double b)
    {
        if (b == 0)
            throw new MathInvalidOperationException("Cannot extract root with zero as the base.");
    
        if (a < 0 && b % 2 == 0)
            throw new MathInvalidOperationException("Cannot extract even root of a negative number.");
        
        var result = Math.Pow(a, 1.0 / b);
        
        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        return result;
    }
}
