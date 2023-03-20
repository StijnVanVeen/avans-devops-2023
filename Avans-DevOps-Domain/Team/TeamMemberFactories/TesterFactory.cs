using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Team.TeamMemberFactories;

public class TesterFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        return new Tester(name, email);
    }
}