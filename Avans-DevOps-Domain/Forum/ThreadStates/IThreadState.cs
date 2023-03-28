namespace Avans_DevOps_Domain.Forum.ThreadStates;

public interface IThreadState
{
    public string Name { get; }
    public void toNextState();
}