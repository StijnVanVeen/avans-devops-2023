using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Notifications;

public class Notifier : IDecoratorComponent, ISubscriber
{
    public TeamMember TeamMember { get; set; }

    public Notifier(TeamMember teamMember)
    {
        TeamMember = teamMember;
    }

    public override void Send(string message)
    {
        Console.WriteLine("All messages are send to "+ TeamMember.Name);
    }
}