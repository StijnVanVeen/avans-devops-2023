using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Teams;

namespace Avans_DevOps_Procescyclus2;

public class ProjectStoryTests
{
    /*
  * Projects
  */
    [Fact]
    public void CanAdd_Project()
    {
        // Arrange
        var title = "TestProject";
        var project = new Project(title);
        var team = new Team("TestTeam");

        // Act
        project.Team = team;

        // Assert
        // A project can be made
        Assert.NotNull(project);

        // A project has a name
        Assert.NotNull(project.Name);
        Assert.Equal(title, project.Name);

        // A project has a team
        Assert.NotNull(project.Team);
        Assert.Equal(team, project.Team);
    }
}