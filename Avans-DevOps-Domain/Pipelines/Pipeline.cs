using Avans_DevOps_Domain.Pipelines.Actions;
using Avans_DevOps_Domain.Publisher;

namespace Avans_DevOps_Domain.Pipelines;

public class Pipeline : IPipeline
{
    public List<IAction> Actions { get; set; }
    public bool LastExecutionSucceeded { get; set; }
    public PipelineEventPublisher Publisher { get; set; }
    public Pipeline()
    {
        LastExecutionSucceeded = false;
        Actions = new List<IAction>();
        Publisher = new PipelineEventPublisher(this);
    }

    public void AddAction(IAction action)
    {
        Actions.Add(action);
    }

    public bool Execute()
    {
        Console.WriteLine("Executing pipeline...");
        
        bool result = false;

        foreach (var action in Actions)
        {
            result = action.Execute();
            if (result == false)
            {
                LastExecutionSucceeded = false;
                Console.WriteLine("Pipeline failed!");
                Console.WriteLine("Stopping pipeline...");
                break;
            }
        }
        
        if (result)
        {
            LastExecutionSucceeded = true;
            Console.WriteLine("Pipeline succeeded!");
        }
        Publisher.PipelineStatus(this);
        return result;
    }
}