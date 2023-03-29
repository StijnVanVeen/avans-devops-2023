namespace Avans_DevOps_Domain.Pipelines.Actions;

public class PackageAction : IAction
{
    public bool Execute()
    {
        try
        {
            Console.WriteLine("Packaging...");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}