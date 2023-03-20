using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain;

public class ReadyForTestingstate: IBacklogItemState
{
    protected IItem item;
    public ReadyForTestingstate(IItem item)
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
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public void toTestingState()
    {
        Console.WriteLine("Transitioning from Doing state to Ready for testing state");
        item.State = item.TestingState;
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
}