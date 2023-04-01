using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Notifications;

public interface ISubscriber
{
    public TeamMember TeamMember { get; set; }
}