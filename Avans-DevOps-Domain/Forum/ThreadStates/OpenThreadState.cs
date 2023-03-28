namespace Avans_DevOps_Domain.Forum.ThreadStates;

public class OpenThreadState : IThreadState
{
    private Thread _thread;

    public string Name { get; }
    
    public OpenThreadState(Thread thread)
    {
        _thread = thread;
        Name = "Open";
    }

    public void toNextState()
    {
        _thread.State = _thread.ClosedState;
    }
}