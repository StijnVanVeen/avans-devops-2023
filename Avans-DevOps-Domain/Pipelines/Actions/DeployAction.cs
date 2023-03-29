namespace Avans_DevOps_Domain.Pipelines.Actions;

public class DeployAction : IAction
{
    public bool Execute()
    {
        try
        {
            Console.WriteLine("Deploying...");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}