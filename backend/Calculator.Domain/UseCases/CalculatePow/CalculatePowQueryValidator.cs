using Calculator.Domain.Exceptions;
using FluentValidation;

namespace Calculator.Domain.UseCases.CalculatePow;

public class CalculatePowQueryValidator : AbstractValidator<CalculatePowQuery>
{
    public CalculatePowQueryValidator()
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
