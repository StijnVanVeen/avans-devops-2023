using Avans_DevOps_Domain.Reports;

namespace Avans_DevOps_Domain.Pipelines.PipelineBuilder;

public class PipelineDocumentationBuilder : IPipelineBuilder
{
    public IReport Report { get; set; }
    
    public PipelineDocumentationBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void AddSourceAction()
    {
        throw new NotImplementedException();
    }

    public void AddPackageAction()
    {
        throw new NotImplementedException();
    }

    public void AddBuildAction()
    {
        throw new NotImplementedException();
    }

    public void AddTestAction()
    {
        throw new NotImplementedException();
    }

    public void AddAnalyseAction()
    {
        throw new NotImplementedException();
    }

    public void AddUtilityAction()
    {
        throw new NotImplementedException();
    }

    public void AddDeployAction()
    {
        throw new NotImplementedException();
    }
    
    public IReport GetReport()
    {
        throw new NotImplementedException();
    }
}