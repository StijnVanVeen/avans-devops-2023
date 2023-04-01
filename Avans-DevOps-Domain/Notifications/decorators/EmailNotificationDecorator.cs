using System.Transactions;

namespace Avans_DevOps_Domain.Notifications;

public class EmailNotificationDecorator : NotificationDecorator
{
    public EmailNotificationDecorator(IDecoratorComponent component) : base(component)
    {
    }
    public override void Send(string message)
    {
        Console.WriteLine("Sending this message via E-mail: " + message);
        base.Send(message);
    }
}