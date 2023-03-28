using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Forum;

public class Forum
{
    public List<Thread> Threads { get; set; }
    public List<TeamMember> Members { get; set; }
    
    private static Forum _instance;
    
    public Forum()
    {
        Threads = new List<Thread>();
        Members = new List<TeamMember>();
    }

    public void AddThread(Thread thread)
    {
        Threads.Add(thread);
    }
    
    public void RemoveThread(Thread thread)
    {
        Threads.Remove(thread);
    }
    
    public void AddMember(TeamMember member)
    {
        Members.Add(member);
    }
    
    public void RemoveMember(TeamMember member)
    {
        Members.Remove(member);
    }
}