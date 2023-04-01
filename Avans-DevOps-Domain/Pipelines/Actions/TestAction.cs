namespace Avans_DevOps_Domain.Pipelines.Actions;

public class TestAction : IAction
{
    public string Name { get; }

    public TestAction()
    {
        Name = "Test Action";
    }

    public bool Execute()
    {
        Console.WriteLine("Testing...");
            return true;
    }
}