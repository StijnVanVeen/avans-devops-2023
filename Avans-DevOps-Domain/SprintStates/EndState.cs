using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class EndState : ISprintState
{

    public string Name { get; }
    public EndState()
    {
        
        this.Name = "End";
    }
    public void toNextState()
    {
        throw new IlligalStateTransitionException();
    }
}