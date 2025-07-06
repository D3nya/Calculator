namespace Calculator.Domain.Exceptions;

public class ValidationErrorCode
{
    public const string Null = nameof(Null);
    public const string Empty = nameof(Empty);
    public const string Overflow = nameof(Overflow);
    public const string Underflow = nameof(Underflow);
    public const string TooLong = nameof(TooLong);
    public const string RestrictedCharacters = nameof(RestrictedCharacters);
    public const string Invalid = nameof(Invalid);
}
