using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain;

public class DoneState : IBacklogItemState
{
    protected IItem item;
    public DoneState(IItem item)
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
        Console.WriteLine("can't go back in states");
        throw new IlligalStateTransitionException();
    }

    public void toTestingState()
    {
        Console.WriteLine("can't go back in states");
        throw new IlligalStateTransitionException();
    }

    public void toTestedState()
    {
        Console.WriteLine("can't go back in states");
        throw new IlligalStateTransitionException();
    }

    public void toDoneState()
    {
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public string toString()
    {
        return "Done State";
    }
}