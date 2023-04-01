namespace Avans_DevOps_Domain.Notifications;

public class SlackNotificationDecorator : NotificationDecorator
{
    public SlackNotificationDecorator(IDecoratorComponent component) : base(component)
    {
    }
    
    public override void Send(string message)
    {
        Console.WriteLine("Sending this message via Slack: " + message);
        base.Send(message);
    }
}