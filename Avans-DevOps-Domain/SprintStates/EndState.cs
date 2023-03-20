using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class EndState : ISprintState
{
    private ISprint _sprint;
    public string Name { get; }
    public EndState(ISprint sprint)
    {
        this._sprint = sprint;
        this.Name = "End";
    }
    public void toNextState()
    {
        throw new IlligalStateTransitionException();
    }
}