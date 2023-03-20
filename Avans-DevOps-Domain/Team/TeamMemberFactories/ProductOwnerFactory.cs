using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Team.TeamMemberFactories;

public class ProductOwnerFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        return new ProductOwner(name, email);
    }
}