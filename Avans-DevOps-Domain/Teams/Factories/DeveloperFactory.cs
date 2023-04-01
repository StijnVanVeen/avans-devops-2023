using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Teams.Factories;

public class DeveloperFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        Console.WriteLine("Creating a new developer...");
        return new Developer(name, email);
    }
}