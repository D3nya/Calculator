using Calculator.Domain.Exceptions;
using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateSubtract;

public class CalculateSubtractQueryValidator : AbstractValidator<CalculateSubtractQuery>
{
    public CalculateSubtractQueryValidator()
    {
        RuleFor(x => x.A)
            .NotNull().WithErrorCode(ValidationErrorCode.Null)
            .LessThan(double.MaxValue).WithErrorCode(ValidationErrorCode.Overflow)
            .GreaterThan(double.MinValue).WithErrorCode(ValidationErrorCode.Underflow);
        
        RuleFor(x => x.B)
            .NotNull().WithErrorCode(ValidationErrorCode.Null)
            .LessThan(double.MaxValue).WithErrorCode(ValidationErrorCode.Overflow)
            .GreaterThan(double.MinValue).WithErrorCode(ValidationErrorCode.Underflow);
    }
}
