using Avans_DevOps_Domain.Notifications;

namespace Avans_DevOps_Domain.Teams.Members;

public abstract class TeamMember
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public ISubscriber Notifier { get; set; }

    public TeamMember(string name, string email)
    {
        Name = name;
        Email = email;
        Notifier = null;
    }
}