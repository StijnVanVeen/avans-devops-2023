using Avans_DevOps_Domain.Reports.Components;

namespace Avans_DevOps_Domain.Reports.Builders;

public class TeamReportBuilder : IReportBuilder
{
    public IReport Report { get; set; }

    public TeamReportBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        Report = new TeamReport();
    }

    public void SetHeader()
    {
        Report.Header = new TeamHeader("Team 1");
    }

    public void SetBody()
    {
        Report.Body = "This is a team report";
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