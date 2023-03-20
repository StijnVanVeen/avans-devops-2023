using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_UnitTest;

public class SprintStateTests
{
    [Fact]
    public void TestSprintInitialState()
    {
        //arrange
        ISprint sprint = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        
        //assert
        Assert.Equal( sprint.InitialState, sprint.State);
    }
    [Fact]
    public void TestSprintInProgresState()
    {
        //arrange
        ISprint sprint = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        sprint.toNextState();
        //assert
        Assert.Equal( sprint.InProgresState, sprint.State);
    }
    [Fact]
    public void TestSprintFinishedState()
    {
        //arrange
        ISprint sprint = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        sprint.toNextState();
        sprint.toNextState();
        //assert
        Assert.Equal( sprint.FinishedState, sprint.State);
    }
    [Fact]
    public void TestSprintReleaseState()
    {
        //arrange
        ISprint sprint = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        sprint.toNextState();
        sprint.toNextState();
        sprint.toNextState();
        //assert
        Assert.Equal( sprint.ReleaseState, sprint.State);
    }
    [Fact]
    public void TestSprintReviewState()
    {
        //arrange
        ISprint sprint = new ReviewSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        sprint.toNextState();
        sprint.toNextState();
        sprint.toNextState();
        //assert
        Assert.Equal( sprint.ReviewState, sprint.State);
    }
    [Fact]
    public void TestSprintReleaseFinishedState()
    {
        //arrange
        ISprint sprint = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        sprint.toNextState();
        sprint.toNextState();
        sprint.toNextState();
        sprint.toNextState();
        //assert
        Assert.Equal( sprint.EndState, sprint.State);
    }
    [Fact]
    public void TestSprintReviewFinishedState()
    {
        //arrange
        ISprint sprint = new ReviewSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
        //act
        sprint.toNextState();
        sprint.toNextState();
        sprint.toNextState();
        sprint.toNextState();
        //assert
        Assert.Equal( sprint.EndState, sprint.State);
    }
}