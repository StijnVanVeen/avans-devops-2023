namespace Avans_DevOps_Domain.Pipelines.Actions;

public class TestAction : IAction
{
    public bool Execute()
    {
        try 
        {
            Console.WriteLine("Testing...");
            return true;
        } 
        catch (Exception e) 
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}