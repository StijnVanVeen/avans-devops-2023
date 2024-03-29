﻿using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain;

public class DoingState : IBacklogItemState
{
    protected IItem item;
    public DoingState(IItem item)
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
        Console.WriteLine("can't go to same state");
        throw new IlligalStateTransitionException();
    }

    public void toReadyForTestingState()
    {
        Console.WriteLine("Transitioning from Doing state to Ready for testing state");
        item.State = item.ReadyForTestingState;
    }

    public void toTestingState()
    {
        Console.WriteLine("can't skip states to testing state");
        throw new IlligalStateTransitionException();
    }

    public void toTestedState()
    {
        Console.WriteLine("can't skip states to tested state");
        throw new IlligalStateTransitionException();
    }

    public void toDoneState()
    {
        Console.WriteLine("can't skip states to done state");
        throw new IlligalStateTransitionException();
    }

    public string toString()
    {
        return "Doing State";
    }
}