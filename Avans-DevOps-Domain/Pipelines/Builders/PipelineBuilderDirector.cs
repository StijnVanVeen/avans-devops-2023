namespace Avans_DevOps_Domain.Pipelines.PipelineBuilder;

public class PipelineBuilderDirector
{
    public IBuilder Builder { get; set; }
    
    public PipelineBuilderDirector(IBuilder builder)
    {
        Builder = builder;
    }
    
    public void SetBuilder(IBuilder builder)
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