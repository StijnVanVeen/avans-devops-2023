using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Teams.Members;
using Avans_DevOps_Domain.Teams.Factories;

namespace Avans_DevOps_Domain.Teams;

public class TeamMemberFactoryDirector
{
    public ITeamMemberFactory Factory { get; set; }
    public TeamMemberFactoryDirector()
    {
        Factory = null;
    }

    public TeamMember CreateDeveloper(string name, string email)
    {
        Factory = new DeveloperFactory();
        return Factory.CreateTeamMember(name, email);
    }
    
    public TeamMember CreateProductOwner(string name, string email)
    {
        Factory = new ProductOwnerFactory();
        return Factory.CreateTeamMember(name, email);
    }
    
    public TeamMember CreateScrumMaster(string name, string email)
    {
        Factory = new ScrumMasterFactory();
        return Factory.CreateTeamMember(name, email);
    }
    
    public TeamMember CreateTester(string name, string email)
    {
        Factory = new TesterFactory();
        return Factory.CreateTeamMember(name, email);
    }
}