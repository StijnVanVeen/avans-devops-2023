using Avans_DevOps_Domain.Reports.Components;

namespace Avans_DevOps_Domain.Reports.Builders;

public class BurnDownReportBuilder : IReportBuilder
{
    public IReport Report { get; set; }
    
    public void Reset()
    {
        Report = new BurnDownReport();
    }
    
    public BurnDownReportBuilder()
    {
        Reset();
    }
    
    public void SetHeader()
    {
        Report.Header = new BurnDownHeader();
    }
    
    public void SetBody()
    {
        Report.Body = "This is a burn down report";
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