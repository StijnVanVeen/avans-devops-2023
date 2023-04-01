using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_UnitTest;

public class ProjectTest
{
    [Fact]
    public void ProjectReleaseSprintTest()
    {
        //arrange
        Project project = new Project("test", null);
        //act
        project.SprintDirector.CreateReleaseSprint("test", new DateOnly(2023,3,29), new DateOnly(2023,4,14));
        //assert
        Assert.Equal(typeof(ReleaseSprint), project.CurrentSprint.GetType());
        Assert.Equal("test", project.CurrentSprint.Name);
        Assert.Equal(new DateOnly(2023,3,29), project.CurrentSprint.StartDate);
        Assert.Equal(new DateOnly(2023,4,14), project.CurrentSprint.EndDate);
    }
    
    [Fact]
    public void ProjectReviewSprintTest()
    {
        //arrange
        Project project = new Project("test", null);
        //act
        project.SprintDirector.CreateReviewSprint("test", new DateOnly(2023,3,29), new DateOnly(2023,4,14));
        //assert
        Assert.Equal(typeof(ReviewSprint), project.CurrentSprint.GetType());
        Assert.Equal(new DateOnly(2023,3,29), project.CurrentSprint.StartDate);
        Assert.Equal(new DateOnly(2023,4,14), project.CurrentSprint.EndDate);
    }
    
    [Fact]
    public void ProjectReleaseSetDatesSprintTest()
    {
        //arrange
        Project project = new Project("test", null);
        //act
        project.SprintDirector.CreateReleaseSprint("test", new DateOnly(2023,3,29), new DateOnly(2023,4,14));
        project.CurrentSprint.StartDate = new DateOnly(2023, 3, 30);
        project.CurrentSprint.EndDate = new DateOnly(2023, 4, 15);
        //assert
        Assert.Equal(new DateOnly(2023,3,30), project.CurrentSprint.StartDate);
        Assert.Equal(new DateOnly(2023,4,15), project.CurrentSprint.EndDate);
    }
    
    [Fact]
    public void ProjectReviewSetDatesSprintTest()
    {
        //arrange
        Project project = new Project("test", null);
        //act
        project.SprintDirector.CreateReviewSprint("test", new DateOnly(2023,3,29), new DateOnly(2023,4,14));
        project.CurrentSprint.StartDate = new DateOnly(2023, 3, 30);
        project.CurrentSprint.EndDate = new DateOnly(2023, 4, 15);
        //assert
        Assert.Equal(new DateOnly(2023,3,30), project.CurrentSprint.StartDate);
        Assert.Equal(new DateOnly(2023,4,15), project.CurrentSprint.EndDate);
    }
    [Fact]
    public void ProjectReleaseNextSprintExceptionTest()
    {
        //arrange
        Project project = new Project("test", null);
        project.SprintDirector.CreateReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        project.SprintDirector.CreateReleaseSprint("Sprint 2", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => project.SprintDirector.NextSprint());
    }
    
    [Fact]
    public void ProjectReviewNextSprintExceptionTest()
    {
        //arrange
        Project project = new Project("test", null);
        project.SprintDirector.CreateReviewSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        project.SprintDirector.CreateReviewSprint("Sprint 2", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => project.SprintDirector.NextSprint());
    }
    [Fact]
    public void ProjectReleaseNextSprintTest()
    {
        //arrange
        Project project = new Project("test", null);
        project.SprintDirector.CreateReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        project.SprintDirector.CreateReleaseSprint("Sprint 2", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        project.CurrentSprint.toNextState();// to inprogress
        project.CurrentSprint.toNextState();// to finished
        project.CurrentSprint.toNextState();// to release
        project.CurrentSprint.toNextState();// to end
        //act
        project.SprintDirector.NextSprint();
        //assert
        Assert.Equal("Sprint 2", project.CurrentSprint.Name);
    }
    
    [Fact]
    public void ProjectReviewNextSprintTest()
    {
        //arrange
        Project project = new Project("test", null);
        project.SprintDirector.CreateReviewSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        project.SprintDirector.CreateReviewSprint("Sprint 2", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        project.CurrentSprint.toNextState();// to inprogress
        project.CurrentSprint.toNextState();// to finished
        project.CurrentSprint.toNextState();// to review
        project.CurrentSprint.toNextState();// to end
        //act
        project.SprintDirector.NextSprint();
        //assert
        Assert.Equal("Sprint 2", project.CurrentSprint.Name);
        
    }
    

}