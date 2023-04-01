using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.SprintStates;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Sprints;

public interface ISprint : IVisitable
{
    public ISprintState InitialState { get; }
    public ISprintState InProgresState { get; }
    public ISprintState FinishedState { get; }
    public ISprintState ReviewState { get; }
    public ISprintState ReleaseState { get; }
    public ISprintState EndState { get; }
    public ISprintState State { get; set; }
    public void toNextState();
    public string Name { get; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public SprintBacklog Backlog { get; set; }
}