using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Forum;

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