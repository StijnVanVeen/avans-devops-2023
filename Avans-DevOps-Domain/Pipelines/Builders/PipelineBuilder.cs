using Avans_DevOps_Domain.Pipelines.Actions;

namespace Avans_DevOps_Domain.Pipelines.PipelineBuilder;

public class PipelineBuilder : IBuilder
{
    public IPipeline Pipeline { get; set; }
    
    public PipelineBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        Console.WriteLine("Resetting pipeline...");
        Pipeline = new Pipeline();
    }
    
    public void AddSourceAction()
    {
        Console.WriteLine("Adding source action...");
        Pipeline.AddAction(new SourceAction());
    }

    public void AddPackageAction()
    {
        Console.WriteLine("Adding package action...");
        Pipeline.AddAction(new PackageAction());
    }

    public void AddBuildAction()
    {
        Console.WriteLine("Adding build action...");
        Pipeline.AddAction(new BuildAction());
    }

    public void AddTestAction()
    {
        Console.WriteLine("Adding test action...");
        Pipeline.AddAction(new TestAction());
    }

    public void AddAnalyseAction()
    {
        Console.WriteLine("Adding analyse action...");
        Pipeline.AddAction(new AnalyseAction());
    }

    public void AddUtilityAction()
    {
        Console.WriteLine("Adding utility action...");
        Pipeline.AddAction(new UtilityAction());
    }

    public void AddDeployAction()
    {
        Console.WriteLine("Adding deploy action...");
        Pipeline.AddAction(new DeployAction());
    }
    
    public IPipeline GetResult()
    {
        IPipeline result = Pipeline;
        Reset();
        return result;
    }
}