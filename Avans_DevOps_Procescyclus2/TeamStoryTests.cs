using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Teams;

namespace Avans_DevOps_Procescyclus2;

public class TeamStoryTests
{
    /*
 * Teams
 */
    [Fact]
    public void CanAdd_Member_ToTeam()
    {
        // Arrange
        var title = "TestProject";
        var project = new Project(title);
        var team = new Team("TestTeam");
        var name = "John Doe";
        var email = "j.doe@avans.nl";
  
        // Act
        project.Team = team;
        project.Team.AddDeveloper(name, email);
        project.Team.AddProductOwner(name, email);
        project.Team.AddScrumMaster(name, email);
        project.Team.AddTester(name, email);
  
        // Assert
        // Developer can be added to team
        Assert.Contains(team.Members, member => member.Role == Role.DEVELOPER);
  
        // Product owner can be added to team
        Assert.Contains(team.Members, member => member.Role == Role.PRODUCT_OWNER);
  
        // Product owner can only be added once
        Assert.Single(team.Members, member => member.Role == Role.PRODUCT_OWNER);
        Assert.Throws<IllegalTeamMemberCreationException>(() => project.Team.AddProductOwner(name, email));
  
        // Scrum master can be added to team
        Assert.Contains(team.Members, member => member.Role == Role.SCRUM_MASTER);
  
        // Scrum master can only be added once
        Assert.Single(team.Members, member => member.Role == Role.SCRUM_MASTER);
        Assert.Throws<IllegalTeamMemberCreationException>(() => project.Team.AddScrumMaster(name, email));
  
        // Tester can be added to team
        Assert.Contains(team.Members, member => member.Role == Role.TESTER);
    }
}