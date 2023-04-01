using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class InProgresState : ISprintState
{
    private readonly ISprint _sprint;
    public string Name { get; }

    public InProgresState(ISprint sprint)
    {
        this._sprint = sprint;
        this.Name = "InProgres";
    }

    public void toNextState()
    {
        _sprint.State = _sprint.FinishedState;
    }
}