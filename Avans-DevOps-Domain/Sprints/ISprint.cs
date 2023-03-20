using Avans_DevOps_Domain.SprintStates;

namespace Avans_DevOps_Domain.Sprints;

public interface ISprint
{
    public ISprintState InitialState { get; }
    public ISprintState InProgresState { get; }
    public ISprintState FinishedState { get; }
    public ISprintState ReviewState { get; }
    public ISprintState ReleaseState { get; }
    public ISprintState EndState { get; }
    public ISprintState State { get; set; }
    public void toNextState();
}