using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Notifications;

public class Notifier : IDecoratorComponent, ISubscriber
{
    public TeamMember TeamMember { get; set; }

    public void Update(IEventPublisher eventPublisher)
    {
        Console.WriteLine("Notifier: Reacted to the event."); 
        Send("A Item has been moved to the ready for testing state");
        
    }

    public override void Send(string message)
    {
        Console.WriteLine("This is the notifier");
    }
}