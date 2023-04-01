using Avans_DevOps_Domain.Teams.Members;
using Thread = Avans_DevOps_Domain.Forums.Thread;

namespace Avans_DevOps_UnitTest;

public class ThreadStateTests
{
    private readonly TeamMember john = new Developer("John Doe", "j.doe@avans.nl");
    [Fact]
    public void TestThreadInitialState()
    {
        //arrange
        const string title = "Test Thread";
        const string description = "My test";
        var thread = new Thread(title, description, john);

        //act

        //assert
        Assert.Equal(title, thread.Title);
        Assert.Equal(description, thread.Description);
        Assert.Equal(john.Name, thread.Author.Name);
        Assert.Equal(john.Email, thread.Author.Email);
        
        Assert.Equal("Open", thread.State.Name);
    }
    
    [Fact]
    public void TestThreadClosedState()
    {
        //arrange
        const string title = "Test Thread";
        const string description = "My test";
        var thread = new Thread(title, description, john);

        //act
        var previousState = thread.State.Name;
        thread.toNextState();

        //assert
        Assert.Equal("Open", previousState);
        Assert.Equal("Closed", thread.State.Name);
        
        Assert.Equal(title, thread.Title);
        Assert.Equal(description, thread.Description);
        Assert.Equal(john.Name, thread.Author.Name);
        Assert.Equal(john.Email, thread.Author.Email);
    }
    
    [Fact]
    public void TestThreadOpenedState()
    {
        //arrange
        const string title = "Test Thread";
        const string description = "My test";
        var thread = new Thread(title, description, john);
        
        //act
        var firstState = thread.State.Name;
        thread.toNextState();
        
        var secondState = thread.State.Name;
        thread.toNextState();

        //assert
        Assert.Equal("Open", firstState);
        Assert.Equal("Closed", secondState);
        Assert.Equal("Open", thread.State.Name);
        
        Assert.Equal(title, thread.Title);
        Assert.Equal(description, thread.Description);
        Assert.Equal(john.Name, thread.Author.Name);
        Assert.Equal(john.Email, thread.Author.Email);
    }
}