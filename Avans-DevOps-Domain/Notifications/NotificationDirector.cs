using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Notifications;

public class NotificationDirector: ISubscriber
{
    public TeamMember TeamMember { get; set; }
    public IDecoratorComponent component { get; set; }

    public NotificationDirector(IDecoratorComponent component)
    {
        this.component = component;
    }
    public void Update(IEventPublisher eventPublisher)
    {
        component.Send("Testing");
    }

    
}