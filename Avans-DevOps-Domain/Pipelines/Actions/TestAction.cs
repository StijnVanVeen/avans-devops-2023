namespace Avans_DevOps_Domain.Pipelines.Actions;

public class TestAction : IAction
{
    public void Execute()
    {
        Console.WriteLine("Testing...");
    }
}