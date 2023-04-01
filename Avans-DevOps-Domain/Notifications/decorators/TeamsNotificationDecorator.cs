namespace Avans_DevOps_Domain.Notifications;

public class TeamsNotificationDecorator : NotificationDecorator
{
    public TeamsNotificationDecorator(IDecoratorComponent component) : base(component)
    {
    }
    
    public override void Send(string message)
    {
        Console.WriteLine("Sending this message via Teams: " + message);
        base.Send(message);
    }
}