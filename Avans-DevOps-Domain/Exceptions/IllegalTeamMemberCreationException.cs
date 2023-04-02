namespace Avans_DevOps_Domain.Exceptions;

public class IllegalTeamMemberCreationException : Exception
{
    public IllegalTeamMemberCreationException()
    {
    }
   
    public IllegalTeamMemberCreationException(string message) : base(message)
    {
    }
   
    public IllegalTeamMemberCreationException(string message, Exception inner) : base(message, inner)
    {
    }
}