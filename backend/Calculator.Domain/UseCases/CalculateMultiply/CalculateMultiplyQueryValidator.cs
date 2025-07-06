using Calculator.Domain.Exceptions;
using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateMultiply;

public class CalculateMultiplyQueryValidator : AbstractValidator<CalculateMultiplyQuery>
{
    public CalculateMultiplyQueryValidator()
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
