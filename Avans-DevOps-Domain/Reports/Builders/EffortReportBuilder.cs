using Avans_DevOps_Domain.Reports.Components;

namespace Avans_DevOps_Domain.Reports.Builders;

public class EffortReportBuilder : IReportBuilder
{
    public IReport Report { get; set; }
    
    public EffortReportBuilder()
    {
        Reset();
    }
    
    public void Reset()
    {
        Report = new EffortReport();
    }

    public void SetHeader()
    {
        Report.Header = new EffortHeader();
    }

    public void SetBody()
    {
        Report.Body = "This is an effort report";
    }

    public void SetFooter()
    {
        Report.Footer = new Footer();
    }
    
    public IReport GetReport()
    {
        IReport report = Report;
        Reset();
        return report;
    }
}