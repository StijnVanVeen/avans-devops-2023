namespace Avans_DevOps_Domain.Pipelines.Actions;

public class PackageAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Packaging...");
        return true;
    }
}