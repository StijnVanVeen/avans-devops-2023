using Avans_DevOps_Domain.Reports.Components;

namespace Avans_DevOps_Domain.Reports.Builders;

public class ReportBuilderDirector
{
    public IReportBuilder Builder { get; set; }
    
    public ReportBuilderDirector(IReportBuilder builder)
    {
        Builder = builder;
    }
    
    public void SetBuilder(IReportBuilder builder)
    {
        Builder = builder;
    }
    
    public void MakeReport()
    {
        Builder.Reset();
        Builder.SetHeader();
        Builder.SetBody();
        Builder.SetFooter();
    }
}