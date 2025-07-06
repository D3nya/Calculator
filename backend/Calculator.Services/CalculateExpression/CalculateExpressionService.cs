using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateExpression;
using DivideByZeroException = System.DivideByZeroException;

namespace Calculator.Services.CalculateExpression;

internal class CalculateExpressionService : ICalculateExpressionService
{
    public double CalculateExpression(string expression)
    {
        try
        {
            var dt = new System.Data.DataTable();
            var value = dt.Compute(expression, null);
            return Convert.ToDouble(value);
        }
        catch
        {
            throw new MathInvalidOperationException("Invalid expression");
        }
    }
}
