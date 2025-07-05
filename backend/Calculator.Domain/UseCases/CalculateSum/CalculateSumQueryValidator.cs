using FluentValidation;

namespace Calculator.Domain.UseCases.CalculateSum;

public class CalculateSumQueryValidator : AbstractValidator<CalculateSumQuery>
{
    public CalculateSumQueryValidator()
    {
        RuleFor(x => x.A)
            .Must(BeFinite)
            .WithMessage("A must be a finite number (not NaN or Infinity).")
            .InclusiveBetween(-1_000_000_000, 1_000_000_000)
            .WithMessage("A must be between -1,000,000,000 and 1,000,000,000.");

        RuleFor(x => x.B)
            .Must(BeFinite)
            .WithMessage("B must be a finite number (not NaN or Infinity).")
            .InclusiveBetween(-1_000_000_000, 1_000_000_000)
            .WithMessage("B must be between -1,000,000,000 and 1,000,000,000.");
    }
    
    private static bool BeFinite(double value)
    {
        return !double.IsNaN(value) && !double.IsInfinity(value);
    }
}
