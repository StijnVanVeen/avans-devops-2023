using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class InitialState : ISprintState
{
    private readonly ISprint _sprint;
    public string Name { get; }

    public InitialState(ISprint sprint)
    {
        this._sprint = sprint;
        this.Name = "Initial";
    }

    public void toNextState()
    {
        _sprint.State = _sprint.InProgresState;
    }
}