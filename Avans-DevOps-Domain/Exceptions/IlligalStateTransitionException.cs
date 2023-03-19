namespace Avans_DevOps_Domain.Exceptions;

public class IlligalStateTransitionException : Exception
{
    public IlligalStateTransitionException()
    {
    }

    public IlligalStateTransitionException(string message) : base(message)
    {
    }

    public IlligalStateTransitionException(string message, Exception inner) : base(message, inner)
    {
    }
}