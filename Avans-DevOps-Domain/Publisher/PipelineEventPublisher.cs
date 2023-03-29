using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;

namespace Avans_DevOps_Domain.Publisher;

public class PipelineEventPublisher : IEventPublisher
{
    public List<ISubscriber> Subscribers { get; set; }

    public void Subscribe(ISubscriber subscriber)
    {
        throw new NotImplementedException();
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        throw new NotImplementedException();
    }

    public void NotifySubscribers()
    {
        throw new NotImplementedException();
    }
}