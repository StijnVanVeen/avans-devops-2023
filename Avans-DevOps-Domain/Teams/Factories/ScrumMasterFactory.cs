using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Team.TeamMemberFactories;

public class ScrumMasterFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        Console.WriteLine("Creating a new scrum master...");
        return new ScrumMaster(name, email);
    }
}