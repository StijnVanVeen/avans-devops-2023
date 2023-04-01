using Avans_DevOps_Domain.Pipelines;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Notifications;

public class PipelineNotificationDirector : IObserver<IPipeline>, ISubscriber
{
    public TeamMember TeamMember { get; set; }
    public IDecoratorComponent Component { get; set; }
    
    public IPipeline Pipeline { get; set; }
    
    private IDisposable cancellation;

    public PipelineNotificationDirector(TeamMember teamMember, IDecoratorComponent component)
    {
        Component = component;
        TeamMember = teamMember;
    }
    
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(IPipeline value)
    {
        Pipeline = value;
        if (value.LastExecutionSucceeded)
        {
            string result = "";
            foreach (var action in value.Actions)
            {
                result += action.Name;
                result += ", ";
            }
            Component.Send("Pipeline has been executed successfully with the following actions: " + result);
        }
        else
        {
            Component.Send("Pipeline execution failed" );
        }
    }
}