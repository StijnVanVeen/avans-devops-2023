using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain;

public class TestingState : IBacklogItemState
{
    protected IItem item;
    public TestingState(IItem item)
    {
        this.item = item;
    }
    public void toToDoState()
    {
        Console.WriteLine("Transitioning from Testing state to ToDo state, testing did not pass");
        item.State = item.TodoState;
    }

    public void toDoingState()
    {
        Console.WriteLine("can't go back in states to doing state");
        throw new IlligalStateTransitionException();
    }

    public void toReadyForTestingState()
    {
        Console.WriteLine("can't go back in states to ready for testing state");
        throw new IlligalStateTransitionException();
    }

    public void toTestingState()
    {
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public void toTestedState()
    {
        Console.WriteLine("Transitioning from Testing state to Tested state, testing passed");
        item.State = item.TestedState;
    }

    public void toDoneState()
    {
        Console.WriteLine("can't skip states to done state");
        throw new IlligalStateTransitionException();
    }

    public string toString()
    {
        return "Testing State";
    }
}