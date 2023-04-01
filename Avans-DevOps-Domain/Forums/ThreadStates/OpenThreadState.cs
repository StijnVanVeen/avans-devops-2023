namespace Avans_DevOps_Domain.Forums.ThreadStates;

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
        Console.WriteLine("Closing thread...");
        _thread.State = _thread.ClosedState;
    }
}