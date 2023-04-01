using Avans_DevOps_Domain.Forums.ThreadStates;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Forums;

public class Thread : ForumComponent
{
    public string Title { get; set; }
    public IThreadState OpenState { get; }
    public IThreadState ClosedState { get; }
    public IThreadState State { get; set; }
    public Thread Parent { get; set; }
    public List<ForumComponent> Children { get; set; }
    
    public Thread (string title, string description, TeamMember author, Thread parent) : base(description, author)
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
        component.Parent = this;
        Children.Add(component);
    }

    public void toNextState()
    {
        Console.WriteLine("Changing thread state...");
        State.toNextState();
    }
}