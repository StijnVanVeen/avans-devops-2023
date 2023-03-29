using Avans_DevOps_Domain.Pipelines.Actions;

namespace Avans_DevOps_Domain.Pipelines;

public class Pipeline : IPipeline
{
    public List<IAction> Actions { get; set; }
    
    public Pipeline()
    {
        Actions = new List<IAction>();
    }

    public void AddAction(IAction action)
    {
        Actions.Add(action);
    }

    public bool Execute()
    {
        bool result = false;

        foreach (var action in Actions)
        {
            result = action.Execute();
            if (result == false)
            {
                break;
            }
        }

        return result;
    }
}