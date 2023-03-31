using Avans_DevOps_Domain.Forum.ThreadStates;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Forum;

public class Thread : ForumComponent
{
    public string Title { get; set; }
    public IThreadState OpenState { get; }
    public IThreadState ClosedState { get; }
    public IThreadState State { get; set; }
    public ForumComponent Parent { get; set; }
    public List<ForumComponent> Children { get; set; }
    
    public Thread (string title, string description, TeamMember author, ForumComponent parent) : base(description, author)
    {
        Title = title;
        OpenState = new OpenThreadState(this);
        ClosedState = new ClosedThreadState(this);
        State = OpenState;
        Parent = parent;
        Children = new List<ForumComponent>();
    }
    
    public Thread (string title, string description, TeamMember author) : base(description, author)
    {
        Title = title;
        OpenState = new OpenThreadState(this);
        ClosedState = new ClosedThreadState(this);
        State = OpenState;
        Parent = null;
        Children = new List<ForumComponent>();
    }
    
    public void Add(ForumComponent component)
    {
        Console.WriteLine("Adding component to thread...");
        Children.Add(component);
        base.Publisher.ForumComponentStatus(component);
    }

    public void toNextState()
    {
        Console.WriteLine("Changing thread state...");
        State.toNextState();
    }
}