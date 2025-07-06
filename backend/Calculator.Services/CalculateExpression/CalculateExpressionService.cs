using Calculator.Domain.Exceptions;
using Calculator.Domain.UseCases.CalculateExpression;
using NCalc;
using NCalc.Factories;

namespace Calculator.Services.CalculateExpression;

internal class CalculateExpressionService(IExpressionFactory expressionFactory) : ICalculateExpressionService
{
    public double CalculateExpression(string expression)
    {
        var nCalcExpression = expressionFactory.Create(expression, ExpressionOptions.IgnoreCaseAtBuiltInFunctions);

        if (nCalcExpression.HasErrors()) throw new InvalidExpressionException();
        
        var result = Convert.ToDouble(nCalcExpression.Evaluate());
            
        if (double.IsInfinity(result)) throw new MathOverflowException();
        
        if(double.IsNaN(result)) throw new MathInvalidOperationException("Invalid operations.");
            
        return result;
    }
}
