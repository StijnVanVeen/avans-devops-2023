using Avans_DevOps_Domain.Pipelines.Actions;

namespace Avans_DevOps_Domain.Pipelines;

public interface IPipeline
{
    public List<IAction> Actions { get; set; }
    
    public void AddAction(IAction action);
    public bool Execute();
}