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
        Pipeline = new Pipeline();
    }
    
    public void AddSourceAction()
    {
        Pipeline.AddAction(new SourceAction());
    }

    public void AddPackageAction()
    {
        Pipeline.AddAction(new PackageAction());
    }

    public void AddBuildAction()
    {
        Pipeline.AddAction(new BuildAction());
    }

    public void AddTestAction()
    {
        Pipeline.AddAction(new TestAction());
    }

    public void AddAnalyseAction()
    {
        Pipeline.AddAction(new AnalyseAction());
    }

    public void AddUtilityAction()
    {
        Pipeline.AddAction(new UtilityAction());
    }

    public void AddDeployAction()
    {
        Pipeline.AddAction(new DeployAction());
    }
    
    public IPipeline GetResult()
    {
        IPipeline result = Pipeline;
        Reset();
        return result;
    }
}