namespace Avans_DevOps_Domain.Forums.ThreadStates;

public interface IThreadState
{
    public string Name { get; }
    public void toNextState();
}