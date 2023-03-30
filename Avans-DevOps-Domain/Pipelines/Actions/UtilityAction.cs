namespace Avans_DevOps_Domain.Pipelines.Actions;

public class UtilityAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Utility...");
        return true;
    }
}