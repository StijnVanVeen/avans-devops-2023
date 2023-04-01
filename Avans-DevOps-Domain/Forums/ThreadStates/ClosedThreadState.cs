namespace Avans_DevOps_Domain.Forums.ThreadStates;

public class ClosedThreadState : IThreadState
{
    private Thread _thread;

    public string Name { get; }
    
    public ClosedThreadState(Thread thread)
    {
        _thread = thread;
        Name = "Closed";
    }

    public void toNextState()
    {
        Console.WriteLine("Opening thread...");
        _thread.State = _thread.OpenState;
    }
}