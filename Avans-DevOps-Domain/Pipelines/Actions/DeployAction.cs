namespace Avans_DevOps_Domain.Pipelines.Actions;

public class DeployAction : IAction
{
    public string Name { get; }

    public DeployAction()
    {
        Name = "Deploy Action";
    }

    public bool Execute()
    {
        Console.WriteLine("Deploying...");
        return true;

    }
}