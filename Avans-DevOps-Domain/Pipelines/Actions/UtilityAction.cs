namespace Avans_DevOps_Domain.Pipelines.Actions;

public class UtilityAction : IAction
{
    public bool Execute()
    {
        try 
        {
            Console.WriteLine("Utility...");
            return true;
        } 
        catch (Exception e) 
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}