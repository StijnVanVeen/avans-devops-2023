using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_UnitTest.Visitor;

public class ReportVisitorTests
{
    [Fact]
    public void VisitTeam_ShouldSetTeamProperty()
    {
        // Arrange
        var visitor = new ReportVisitor();
        var team = new Team("Test");
        
        // Act
        team.Accept(visitor);
        
        // Assert
        Assert.Equal(team, visitor.Team);
    }
    
    [Fact]
    public void VisitBacklog_ShouldSetBacklogProperty()
    {
        // Arrange
        var visitor = new ReportVisitor();
        var backlog = new SprintBacklog();
        
        // Act
        backlog.Accept(visitor);
        
        // Assert
        Assert.Equal(backlog, visitor.Backlog);
    }
    
    [Fact]
    public void VisitSprint_ShouldSetSprintProperty()
    {
        // Arrange
        var visitor = new ReportVisitor();
        var sprint = new ReleaseSprint("Test", DateOnly.MinValue, DateOnly.MaxValue);
        
        // Act
        sprint.Accept(visitor);
        
        // Assert
        Assert.Equal(sprint, visitor.Sprint);
    }
    
    [Fact]
    public void VisitProject_ShouldSetProjectProperty()
    {
        // Arrange
        var visitor = new ReportVisitor();
        var project = new Project("Test", new Team("Test"));
        
        // Act
        project.Accept(visitor);
        
        // Assert
        Assert.Equal(project, visitor.Project);
    }
}