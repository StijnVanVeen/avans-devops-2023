namespace Avans_DevOps_Domain.Pipelines.Actions;

public class UtilityAction : IAction
{
    public string Name { get; }

    public UtilityAction()
    {
        Name = "Utility Action";
    }

    public bool Execute()
    {
        Console.WriteLine("Utility...");
        return true;
    }
}