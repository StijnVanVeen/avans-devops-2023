namespace Avans_DevOps_Domain.Pipelines.Actions;

public class SourceAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Getting source...");
        return true;
    }
}