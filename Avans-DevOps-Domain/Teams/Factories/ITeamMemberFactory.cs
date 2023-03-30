using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Team.TeamMemberFactories;

public interface ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email);
}