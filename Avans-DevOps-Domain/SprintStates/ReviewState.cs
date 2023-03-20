using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class ReviewState : ISprintState
{
    private ISprint _sprint;
    public string Name { get; }

    public ReviewState(ISprint sprint)
    {
        this._sprint = sprint;
        this.Name = "Review";
    }

    public void toNextState()
    {
        _sprint.State = _sprint.EndState;
    }
}