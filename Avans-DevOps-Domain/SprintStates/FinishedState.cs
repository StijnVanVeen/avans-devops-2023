using Avans_DevOps_Domain.Sprints;

namespace Avans_DevOps_Domain.SprintStates;

public class FinishedState : ISprintState
{
    private ISprint _sprint;
    public string Name { get; }

    public FinishedState(ISprint sprint)
    {
        this._sprint = sprint;
        this.Name = "Finished";
    }

    public void toNextState()
    {
        if (_sprint.GetType() == typeof(ReleaseSprint))
        {
            _sprint.State = _sprint.ReleaseState;
        }

        if (_sprint.GetType() == typeof(ReviewSprint))
        {
            _sprint.State = _sprint.ReviewState;
        }
    }
}