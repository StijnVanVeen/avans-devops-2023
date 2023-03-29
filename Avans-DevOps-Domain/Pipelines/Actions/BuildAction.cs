namespace Avans_DevOps_Domain.Pipelines.Actions;

public class BuildAction : IAction
{
    public void Execute()
    {
        Console.WriteLine("Building...");
    }
}