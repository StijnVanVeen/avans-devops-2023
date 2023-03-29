namespace Avans_DevOps_Domain.Pipelines.Actions;

public class AnalyseAction : IAction
{
    public bool Execute()
    {
        try 
        {
            Console.WriteLine("Analysing...");
            return true;
        } 
        catch (Exception e) 
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}