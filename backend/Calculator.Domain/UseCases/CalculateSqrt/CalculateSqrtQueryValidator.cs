using Calculator.Domain.Exceptions;
using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateSqrt;

public class CalculateSqrtQueryValidator : AbstractValidator<CalculateSqrtQuery>
{
    public CalculateSqrtQueryValidator()
    {
        RuleFor(x => x.A)
            .NotNull().WithErrorCode(ValidationErrorCode.Null)
            .LessThan(double.MaxValue).WithErrorCode(ValidationErrorCode.Overflow)
            .GreaterThan(double.MinValue).WithErrorCode(ValidationErrorCode.Underflow);
        
        RuleFor(x => x.B)
            .LessThan(double.MaxValue).WithErrorCode(ValidationErrorCode.Overflow)
            .GreaterThan(double.MinValue).WithErrorCode(ValidationErrorCode.Underflow);       
    }
}
