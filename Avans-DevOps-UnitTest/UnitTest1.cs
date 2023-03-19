using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_UnitTest;

public class UnitTestForBacklogItemState
{
    [Fact]
    public void ItemStateToDoTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        //act
        item.ChangeStateToDoing();
        //assert
        Assert.Equal( item.DoingState, item.State);
    }
    [Fact]
    public void ItemStateTestToDoToReadyForTestingException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToReadyForTesting());
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void ItemStateTestToDoToTestingException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void ItemStateTestToDoToTestedException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.TodoState, item.State);
    }
    
    [Fact]
    public void ItemStateTestToDoToDoneException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.TodoState, item.State);
    }
    
    //============================================================================
    
    [Fact]
    public void ItemStateDoingToReadyForTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        //act
        item.ChangeStateToReadyForTesting();
        //assert
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void ItemStateTestDoingToTestingException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.DoingState, item.State);
    }
    [Fact]
    public void ItemStateTestDoingToTestedException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.DoingState, item.State);
    }
    [Fact]
    public void ItemStateTestDoingToDoneException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.DoingState, item.State);
    }
    
    //============================================================================
    
    [Fact]
    public void ItemStateReadyForTestingTestToTesting()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act
        item.ChangeStateToTesting();
        //assert
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void ItemStateReadyForTestingToTodoTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void ItemStateReadyForTestingToDoingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void ItemStateReadyForTestingToTestedTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void ItemStateReadyForTestingToDoneTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    
    //============================================================================
    
    [Fact]
    public void ItemStateTestingToTested()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act
        item.ChangeStateToTested();
        //assert
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestingToTodoTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        item.ChangeStateToToDo();
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void ItemStateTestingToDoingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void ItemStateTestingToReadyForTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void ItemStateTestingToTestedTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        item.ChangeStateToTested();
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestingToDoneTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.TestingState, item.State);
    }
    
    //============================================================================
    [Fact]
    public void ItemStateTestedToToDoTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestedToDoingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestedToReadyForTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act
        item.ChangeStateToTested();
        //assert
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestedToTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestedToTestedTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void ItemStateTestedToDoneTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act
        item.ChangeStateToDone();
        //assert
        Assert.Equal(item.DoneState, item.State);
    }
}