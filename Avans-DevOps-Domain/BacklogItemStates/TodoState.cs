using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain;

public class TodoState : IBacklogItemState
{
    protected IItem item;

    public TodoState(IItem item)
    {
        this.item = item;
    }
    
    public void toToDoState()
    {
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public void toDoingState()
    {
        Console.WriteLine("Transitioning from ToDo state to Doing state");
        item.State = item.DoingState;
    }

    public void toReadyForTestingState()
    {
        Console.WriteLine("can't skip states");
        throw new IlligalStateTransitionException();
    }

    public void toTestingState()
    {
        Console.WriteLine("can't skip states");
        throw new IlligalStateTransitionException();
    }

    public void toTestedState()
    {
        Console.WriteLine("can't skip states");
        throw new IlligalStateTransitionException();
    }

    public void toDoneState()
    {
        Console.WriteLine("can't skip states");
        throw new IlligalStateTransitionException();
    }

    public string toString()
    {
        return "ToDo State";
    }
}