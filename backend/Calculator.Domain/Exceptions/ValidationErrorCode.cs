namespace Calculator.Domain.Exceptions;

public class ValidationErrorCode
{
    public const string Null = nameof(Null);
    public const string Overflow = nameof(Overflow);
    public const string Underflow = nameof(Underflow);
}
