namespace Avans_DevOps_Domain.Pipelines.Actions;

public class DeployAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Deploying...");
        return true;

    }
}