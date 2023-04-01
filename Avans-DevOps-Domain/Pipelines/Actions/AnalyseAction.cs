namespace Avans_DevOps_Domain.Pipelines.Actions;

public class AnalyseAction : IAction
{
    public string Name { get; }

    public AnalyseAction()
    {
        Name = "Analyse Action";
    }
    public bool Execute()
    {
        Console.WriteLine("Analising...");
        return true;
    }
}