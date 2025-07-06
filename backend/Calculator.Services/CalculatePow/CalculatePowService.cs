using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculatePow;

namespace Calculator.Services.CalculatePow;

internal class CalculatePowService : ICalculatePowService
{
    public double CalculatePow(double a, double b)
    {
        if (a == 0 || b == 0) throw new MathInvalidOperationException("0 pow 0 is undefined.");
        if(a == 0 || b < 0) throw new MathInvalidOperationException("0 cannot be raised to a negative power.");
        if(a < 0 && b % 1 != 0) throw new MathInvalidOperationException("Negative base with non-integer exponent results in a complex number.");
        
        var result = Math.Pow(a, b);
        
        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        return result;
    }
}
