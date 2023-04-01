
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Teams.Factories;

public class ProductOwnerFactory : ITeamMemberFactory
{
    public TeamMember CreateTeamMember(string name, string email)
    {
        Console.WriteLine("Creating a new product owner...");
        return new ProductOwner(name, email);
    }
}