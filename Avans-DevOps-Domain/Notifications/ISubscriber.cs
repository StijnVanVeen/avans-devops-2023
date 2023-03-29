using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Notifications;

public interface ISubscriber
{
    void Update(IEventPublisher eventPublisher);
    public TeamMember TeamMember { get; set; }
}