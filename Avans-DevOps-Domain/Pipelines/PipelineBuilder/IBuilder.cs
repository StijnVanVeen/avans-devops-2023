namespace Avans_DevOps_Domain.Pipelines.PipelineBuilder;

public interface IBuilder
{
    public void Reset();
    public void AddSourceAction();
    public void AddPackageAction();
    public void AddBuildAction();
    public void AddTestAction();
    public void AddAnalyseAction();
    public void AddUtilityAction();
    public void AddDeployAction();
}