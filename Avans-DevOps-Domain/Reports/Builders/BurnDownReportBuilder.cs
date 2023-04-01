using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Reports.Components;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Reports.Builders;

public class BurnDownReportBuilder : IReportBuilder
{
    public IReport Report { get; set; }
    public ReportVisitor Visitor { get; set; }
    
    public void Reset()
    {
        Report = new BurnDownReport();
    }
    
    public BurnDownReportBuilder(ReportVisitor reportVisitor)
    {
        Visitor = reportVisitor;
        Reset();
    }

    public void SetHeader()
    {
        Report.Header = new BurnDownHeader();
    }
    
    public void SetBody()
    {
        if (Visitor != null)
        {
            var backlog = Visitor.Backlog;
            var totalStoryPoints = 0;

            foreach (var item in backlog.BacklogItems)
            {
                var w = item as WorkItem;
                totalStoryPoints += w.StoryPoints;
            }

            Report.Body = $"This is backlog contains: {backlog.BacklogItems.Count} items with a total of {totalStoryPoints} story points.";
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