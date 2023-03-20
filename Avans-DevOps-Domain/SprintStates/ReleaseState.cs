using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class ReleaseState : ISprintState
{
    private ISprint _sprint;
    public string Name { get; }

    public ReleaseState(ISprint sprint)
    {
        this._sprint = sprint;
        this.Name = "Release";
    }

    public void toNextState()
    {
        _sprint.State = _sprint.EndState;
    }
}