using Avans_DevOps_Domain.Reports.Components;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Reports.Builders;

public class TeamReportBuilder : IReportBuilder
{
    public IReport Report { get; set; }
    public ReportVisitor Visitor { get; set; }
    
    public TeamReportBuilder(ReportVisitor visitor)
    {
        Visitor = visitor;
        Reset();
    }

    public void Reset()
    {
        Report = new TeamReport();
    }

    public void SetHeader()
    {
        if (Visitor != null)
        {
            var name = Visitor.Team.Name;
            Report.Header = new TeamHeader(name);
        }
    }

    public void SetBody()
    {
        if (Visitor != null)
        {
            var team = Visitor.Team;
            var members = "";
            
            foreach (var member in team.Members)
            {
                members += $"{member.Name}\n";
            }
            
            Report.Body = $"Team: {team.Name}, currently has {team.Members.Count} members:\n" + members;
        }
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