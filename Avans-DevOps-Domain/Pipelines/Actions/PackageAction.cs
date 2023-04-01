namespace Avans_DevOps_Domain.Pipelines.Actions;

public class PackageAction : IAction
{
    public string Name { get; }

    public PackageAction()
    {
        Name = "Package Action";
    }

    public bool Execute()
    {
        Console.WriteLine("Packaging...");
        return true;
    }
}