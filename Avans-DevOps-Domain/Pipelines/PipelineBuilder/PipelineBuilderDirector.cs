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

    public IPipeline MakePipeline(IBuilder builder)
    {
        builder.AddSourceAction();
        builder.AddPackageAction();
        builder.AddBuildAction();
        builder.AddTestAction();
        builder.AddAnalyseAction();
        builder.AddUtilityAction();
        builder.AddDeployAction();
        
        return builder.GetResult();
    }
}