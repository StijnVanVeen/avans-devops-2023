using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Notifications;

public class ForumNotificationDirector : IObserver<ForumComponent>
{
    public TeamMember TeamMember { get; set; }
    public IDecoratorComponent Component { get; set; }
    
    public ForumComponent? ForumComponent { get; set; }
    
    private IDisposable cancellation;

    public ForumNotificationDirector(TeamMember teamMember, IDecoratorComponent component)
    {
        Component = component;
        TeamMember = teamMember;
    }
    
    public virtual void Subscribe(ForumComponentEventPublisher provider)
    {
        cancellation = provider.Subscribe(this);
    }

    public virtual void Unsubscribe()
    {
        cancellation.Dispose();
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(ForumComponent value)
    {
        Component.Send(value.Author.Name + " said: " + value.Description);
    }
}