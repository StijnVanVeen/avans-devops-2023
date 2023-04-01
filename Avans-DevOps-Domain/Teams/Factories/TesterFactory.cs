using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Teams.Factories;

public class TesterFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        Console.WriteLine("Creating a new tester...");
        return new Tester(name, email);
    }
}