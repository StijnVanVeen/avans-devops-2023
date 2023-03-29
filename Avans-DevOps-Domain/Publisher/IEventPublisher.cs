using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;

namespace Avans_DevOps_Domain.Publisher;

public interface IEventPublisher
{
    public void Subscribe(ISubscriber subscriber);
    public void Unsubscribe(ISubscriber subscriber);
    public void NotifySubscribers();
}