using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Teams.Factories;

public class ScrumMasterFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        Console.WriteLine("Creating a new scrum master...");
        return new ScrumMaster(name, email);
    }
}