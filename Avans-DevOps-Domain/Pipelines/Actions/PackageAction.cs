namespace Avans_DevOps_Domain.Pipelines.Actions;

public class PackageAction : IAction
{
    public void Execute()
    {
        Console.WriteLine("Packaging...");
    }
}