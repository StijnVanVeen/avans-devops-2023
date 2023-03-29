using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Team;

namespace Avans_DevOps_Domain.Publisher;

public class BacklogItemEventPublisher : IEventPublisher
{
    public List<ISubscriber> Subscribers { get; set; }
    public IItem item { get; set; }

    public BacklogItemEventPublisher(IItem item)
    {
        Subscribers = new List<ISubscriber>();
        this.item = item;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        Console.WriteLine("BacklogItemEventPublisher: Added a Subscriber");
        Subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        Console.WriteLine("BacklogItemEventPublisher: Removed a Subscriber");
        Subscribers.Remove(subscriber);
    }

    public void NotifySubscribers()
    {
        Console.WriteLine("BacklogItemEventPublisher: Notifying subscribers...");

        if (item.State == item.ReadyForTestingState)
        {
            foreach (var subscriber in Subscribers.FindAll(x => x.TeamMember.Role == Role.TESTER))
            {
                subscriber.Update(this);
            }
        }
        
        foreach (var subscriber in Subscribers)
        {
            subscriber.Update(this);
        }
    }
}