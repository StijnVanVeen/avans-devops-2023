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
        Console.WriteLine("can't go back in states to todo state");
        throw new IlligalStateTransitionException();
    }

    public void toDoingState()
    {
        Console.WriteLine("can't go back in states to doing");
        throw new IlligalStateTransitionException();
    }

    public void toReadyForTestingState()
    {
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public void toTestingState()
    {
        item.State = item.TestingState;
    }

    public void toTestedState()
    {
        Console.WriteLine("can't skip states to testes state");
        throw new IlligalStateTransitionException();
    }

    public void toDoneState()
    {
        Console.WriteLine("can't skip states to done state");
        throw new IlligalStateTransitionException();
    }

    public string toString()
    {
        return "Ready For Testing State";
    }
}