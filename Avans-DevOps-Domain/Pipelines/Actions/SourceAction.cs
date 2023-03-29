namespace Avans_DevOps_Domain.Pipelines.Actions;

public class SourceAction : IAction
{
    public void Execute()
    {
        Console.WriteLine("Source action executed...");
    }
}