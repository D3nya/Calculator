using System.Text.RegularExpressions;
using Calculator.Domain.Exceptions;
using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateExpression;

public partial class CalculateExpressionQueryValidator : AbstractValidator<CalculateExpressionQuery>
{
    public CalculateExpressionQueryValidator()
    {
        RuleFor(x => x.Expression)
            .NotEmpty().WithErrorCode(ValidationErrorCode.Empty)
            .MaximumLength(200).WithErrorCode(ValidationErrorCode.TooLong)
            .Must(BeValidCharacters).WithErrorCode(ValidationErrorCode.RestrictedCharacters)
            .Must(HaveBalancedParentheses).WithErrorCode(ValidationErrorCode.Invalid);
    }
    
    [GeneratedRegex(@"^[0-9+\-*/^().\s]+$")]
    private static partial Regex ExpressionRegex();
    
    private static bool BeValidCharacters(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) return false;
        
        var regex = ExpressionRegex();
        return regex.IsMatch(expression);
    }

    private static bool HaveBalancedParentheses(string expression)
    {
        var queue = 0;

        foreach (var ch in expression)
        {
            switch (ch)
            {
                case '(':
                    queue++;
                    break;
                case ')':
                    queue--;
                    break;
            }

            if (queue < 0) return false;
        }

        return queue == 0;
    }
}
