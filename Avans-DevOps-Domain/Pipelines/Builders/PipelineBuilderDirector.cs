namespace Avans_DevOps_Domain.Pipelines.PipelineBuilder;

public class PipelineBuilderDirector
{
    public IPipelineBuilder Builder { get; set; }
    
    public PipelineBuilderDirector(IPipelineBuilder builder)
    {
        Builder = builder;
    }
    
    public void SetBuilder(IPipelineBuilder builder)
    {
        Builder = builder;
    }

    public void MakePipeline()
    {
        Builder.Reset();
        Builder.AddSourceAction();
        Builder.AddPackageAction();
        Builder.AddBuildAction();
        Builder.AddTestAction();
        Builder.AddAnalyseAction();
        Builder.AddUtilityAction();
        Builder.AddDeployAction();
    }
}