namespace Calculator.Domain.Exceptions;

public class DivideByZeroException()
    : DomainException(DomainErrorCode.UnprocessableEntity, "Divide by zero is not allowed.");
