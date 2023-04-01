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
    public void ItemStateTestToDoToToDoException()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.TodoState, item.State);
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
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToReadyForTesting());
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void ItemStateTestingToTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
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
    //============================================================================
     [Fact]
    public void ItemStateDoneToToDoTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void ItemStateDoneToDoingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void ItemStateDoneToReadyForTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToReadyForTesting());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void ItemStateDoneToTestingTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void ItemStateDoneToDoneTest()
    {
        //arrange
        WorkItem item = new WorkItem("Workitem", "description", 1);
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.DoneState, item.State);
    }
    //=======================================================================================
    //=======================================================================================
    
    [Fact]
    public void WorkTaskStateToDoTest()
    {
        //arrange
        var item = new WorkTask ("WorkTask", "description");
        //act
        item.ChangeStateToDoing();
        //assert
        Assert.Equal( item.DoingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestToDoToToDoException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestToDoToReadyForTestingException()
    {
        //arrange
        var item = new WorkItem("WorkTask", "description", 1);
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToReadyForTesting());
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestToDoToTestingException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestToDoToTestedException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.TodoState, item.State);
    }
    
    [Fact]
    public void WorkTaskStateTestToDoToDoneException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.TodoState, item.State);
    }
    
    //============================================================================
    
    [Fact]
    public void WorkTaskStateDoingToReadyForTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        //act
        item.ChangeStateToReadyForTesting();
        //assert
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestDoingToTestingException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.DoingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestDoingToTestedException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.DoingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestDoingToDoneException()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.DoingState, item.State);
    }
    
    //============================================================================
    
    [Fact]
    public void WorkTaskStateReadyForTestingTestToTesting()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act
        item.ChangeStateToTesting();
        //assert
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateReadyForTestingToTodoTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateReadyForTestingToDoingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateReadyForTestingToTestedTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateReadyForTestingToDoneTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.ReadyForTestingState, item.State);
    }
    
    //============================================================================
    
    [Fact]
    public void WorkTaskStateTestingToTested()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act
        item.ChangeStateToTested();
        //assert
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestingToTodoTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        item.ChangeStateToToDo();
        Assert.Equal(item.TodoState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestingToDoingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestingToReadyForTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToReadyForTesting());
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestingToTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.TestingState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestingToTestedTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        item.ChangeStateToTested();
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestingToDoneTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.TestingState, item.State);
    }
    
    //============================================================================
    [Fact]
    public void WorkTaskStateTestedToToDoTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestedToDoingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestedToReadyForTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        //act
        item.ChangeStateToTested();
        //assert
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestedToTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestedToTestedTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTested());
        Assert.Equal(item.TestedState, item.State);
    }
    [Fact]
    public void WorkTaskStateTestedToDoneTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        //act
        item.ChangeStateToDone();
        //assert
        Assert.Equal(item.DoneState, item.State);
    }
    //============================================================================
     [Fact]
    public void WorkTaskStateDoneToToDoTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToToDo());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void WorkTaskStateDoneToDoingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDoing());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void WorkTaskStateDoneToReadyForTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToReadyForTesting());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void WorkTaskStateDoneToTestingTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToTesting());
        Assert.Equal(item.DoneState, item.State);
    }
    [Fact]
    public void WorkTaskStateDoneToDoneTest()
    {
        //arrange
        var item = new WorkTask("WorkTask", "description");
        item.ChangeStateToDoing();
        item.ChangeStateToReadyForTesting();
        item.ChangeStateToTesting();
        item.ChangeStateToTested();
        item.ChangeStateToDone();
        //act & assert
        Assert.Throws<IlligalStateTransitionException>(() => item.ChangeStateToDone());
        Assert.Equal(item.DoneState, item.State);
    }
}