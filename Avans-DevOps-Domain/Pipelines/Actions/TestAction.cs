namespace Avans_DevOps_Domain.Pipelines.Actions;

public class TestAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Testing...");
            return true;
    }
}