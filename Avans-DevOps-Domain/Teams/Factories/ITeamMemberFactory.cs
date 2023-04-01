using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Teams.Factories;

public interface ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email);
}