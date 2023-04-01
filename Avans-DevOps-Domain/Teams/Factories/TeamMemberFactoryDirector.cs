using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Teams.Members;
using Avans_DevOps_Domain.Teams.Factories;

namespace Avans_DevOps_Domain.Teams;

public class TeamMemberFactoryDirector
{
    public ITeamMemberFactory Factory { get; set; }
    public Project Project { get; set; }
    
    public TeamMemberFactoryDirector()
    {
        Factory = null;
        Project = null;
    }
    
    public TeamMemberFactoryDirector(Project project)
    {
        Factory = null;
        Project = project;
    }

    public TeamMember CreateDeveloper(string name, string email)
    {
        Factory = new DeveloperFactory();
        return Factory.CreateTeamMember(name, email);
    }
    
    public TeamMember CreateProductOwner(string name, string email)
    {
        if (Project.Team.Members.Contains(Project.Team.Members.FirstOrDefault(member => member.Role == Role.PRODUCT_OWNER)))
        {
            throw new IllegalTeamMemberCreationException("There can only be one product owner in a team");
        }

        Factory = new ProductOwnerFactory();
        return Factory.CreateTeamMember(name, email);
    }
    
    public TeamMember CreateScrumMaster(string name, string email)
    {
        if (Project.Team.Members.Contains(Project.Team.Members.FirstOrDefault(member => member.Role == Role.SCRUM_MASTER)))
        {
            throw new IllegalTeamMemberCreationException("There can only be one scrum master in a team");
        }
        
        Factory = new ScrumMasterFactory();
        return Factory.CreateTeamMember(name, email);
    }
    
    public TeamMember CreateTester(string name, string email)
    {
        Factory = new TesterFactory();
        return Factory.CreateTeamMember(name, email);
    }
}