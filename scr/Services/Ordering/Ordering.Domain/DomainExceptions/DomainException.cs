namespace Ordering.Domain.DomainExceptions;

public class DomainException : Exception
{
    public DomainException(string message) 
        : base($"Domain exception : {message} throws from domain layer.")
    {}
}
