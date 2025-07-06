using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateSubtract;

namespace Calculator.Services.CalculateSubtract;

public class CalculateSubtractService :  ICalculateSubtractService
{
    public double CalculateSubtract(double a, double b)
    {
        var result = a - b;
        
        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        return result;
    }
}
