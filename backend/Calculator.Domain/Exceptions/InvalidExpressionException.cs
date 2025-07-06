namespace Calculator.Domain.Exceptions;

public class InvalidExpressionException() : DomainException(DomainErrorCode.UnprocessableEntity, "Invalid expression.");
