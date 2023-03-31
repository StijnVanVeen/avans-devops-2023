using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain;

public class TestedState : IBacklogItemState
{
    protected IItem item;
    public TestedState(IItem item)
    {
        this.item = item;
    }
    public void toToDoState()
    {
        Console.WriteLine("can't go back in states");
        throw new IlligalStateTransitionException();
    }

    public void toDoingState()
    {
        Console.WriteLine("can't go back in states");
        throw new IlligalStateTransitionException();
    }

    public void toReadyForTestingState()
    {
        Console.WriteLine("Transitioning from Tested state to Ready for testing state");
        item.State = item.TestedState;
    }

    public void toTestingState()
    {
        Console.WriteLine("can't go back in states");
        throw new IlligalStateTransitionException();
    }

    public void toTestedState()
    {
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public void toDoneState()
    {
        Console.WriteLine("Transitioning from Tested state to Done state");
        item.State = item.DoneState;
    }

    public string toString()
    {
        return "Tested State";
    }
}