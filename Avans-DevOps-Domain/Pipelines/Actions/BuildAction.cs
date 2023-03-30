namespace Avans_DevOps_Domain.Pipelines.Actions;

public class BuildAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Building...");
        return true;
    }
}