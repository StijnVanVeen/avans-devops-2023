namespace Avans_DevOps_Domain.SprintStates;

public interface ISprintState
{
    public string Name { get; }
    public void toNextState();
}