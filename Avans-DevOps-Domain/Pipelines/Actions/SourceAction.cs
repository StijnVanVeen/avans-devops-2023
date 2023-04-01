namespace Avans_DevOps_Domain.Pipelines.Actions;

public class SourceAction : IAction
{
    public string Name { get; }

    public SourceAction()
    {
        Name = "Source Action";
    }

    public bool Execute()
    {
        Console.WriteLine("Getting source...");
        return true;
    }
}