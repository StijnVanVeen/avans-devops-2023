namespace Avans_DevOps_Domain.Forums;

public class Forum
{
    public List<Thread> Threads { get; set; }

    public Forum()
    {
        Threads = new List<Thread>();
    }

    public void AddThread(Thread thread)
    {
        Console.WriteLine("Adding thread to forum...");
        Threads.Add(thread);
    }
}