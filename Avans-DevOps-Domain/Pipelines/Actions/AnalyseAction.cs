namespace Avans_DevOps_Domain.Pipelines.Actions;

public class AnalyseAction : IAction
{
    public bool Execute()
    {
        Console.WriteLine("Analising...");
        return true;
    }
}