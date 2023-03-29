namespace Avans_DevOps_Domain.Pipelines.Actions;

public class SourceAction : IAction
{
    public bool Execute()
    {
        try
        {
            Console.WriteLine("Getting source...");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}