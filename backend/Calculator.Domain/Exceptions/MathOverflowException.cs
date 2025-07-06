namespace Calculator.Domain.Exceptions;

public class MathOverflowException() : DomainException(DomainErrorCode.UnprocessableEntity, "The result is too large to represent as a double");
