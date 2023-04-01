namespace Avans_DevOps_Domain.Pipelines.Actions;

public class BuildAction : IAction
{
    public string Name { get; }

    public BuildAction()
    {
        Name = "Build Action";
    }

    public bool Execute()
    {
        Console.WriteLine("Building...");
        return true;
    }
}