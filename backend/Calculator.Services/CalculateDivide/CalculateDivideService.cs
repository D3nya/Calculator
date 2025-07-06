using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateDivide;
using DivideByZeroException = Calculator.Domain.Exceptions.DivideByZeroException;

namespace Calculator.Services.CalculateDivide;

internal class CalculateDivideService : ICalculateDivideService
{
    public double CalculateDivide(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException();
        
        var result = a / b;
        
        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        return result;
    }
}
