namespace Calculator.Domain.Exceptions;

public class MathInvalidOperationException(string message) : DomainException(DomainErrorCode.UnprocessableEntity, $"Math operation is invalid. {message}");
