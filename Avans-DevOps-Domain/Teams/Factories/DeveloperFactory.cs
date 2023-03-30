using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Team.TeamMemberFactories;

public class DeveloperFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        Console.WriteLine("Creating a new developer...");
        return new Developer(name, email);
    }
}