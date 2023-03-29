namespace Avans_DevOps_Domain.Pipelines.Actions;

public class DeployAction : IAction
{
    public void Execute()
    {
        Console.WriteLine("Deploying...");
    }
}