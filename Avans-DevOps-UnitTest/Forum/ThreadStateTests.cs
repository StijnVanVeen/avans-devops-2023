using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_UnitTest;

public class ThreadStateTests
{
    [Fact]
    public void TestThreadInitialState()
    {
        //arrange
        TeamMember john = new Developer("John", "Doe");
        Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread("Test thread", "My test", john);

        //act

        //assert
        Assert.Equal("Open", thread.State.Name);
    }
    
    [Fact]
    public void TestThreadClosedState()
    {
        //arrange
        TeamMember john = new Developer("John", "Doe");
        Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread("Test thread", "My test", john);

        //act
        thread.State.toNextState();

        //assert
        Assert.Equal("Closed", thread.State.Name);
    }
    
    [Fact]
    public void TestThreadOpenedState()
    {
        //arrange
        TeamMember john = new Developer("John", "Doe");
        Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread("Test thread", "My test", john);

        //act
        thread.State.toNextState();
        thread.State.toNextState();

        //assert
        Assert.Equal("Open", thread.State.Name);
    }
}