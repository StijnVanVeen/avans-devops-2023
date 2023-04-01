namespace Avans_DevOps_Domain.Notifications;

public abstract class IDecoratorComponent
{
    public abstract void Send(string message);
}