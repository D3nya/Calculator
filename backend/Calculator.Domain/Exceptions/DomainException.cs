namespace Calculator.Domain.Exceptions;

public abstract class DomainException(DomainErrorCode code, string message) : Exception(message)
{
    public DomainErrorCode DomainErrorCode { get; } = code;
}
