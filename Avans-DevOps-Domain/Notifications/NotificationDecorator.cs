namespace Avans_DevOps_Domain.Notifications;

public abstract class NotificationDecorator : IDecoratorComponent
{
    protected IDecoratorComponent Component { get; set; }

    protected NotificationDecorator(IDecoratorComponent component)
    {
        Component = component;
    }

    public override void Send(string message)
    {
        if (Component != null)
        { 
            Component.Send(message);
        }
    }
}