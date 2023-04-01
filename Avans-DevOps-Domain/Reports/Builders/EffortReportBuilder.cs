using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Reports.Components;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Reports.Builders;

public class EffortReportBuilder : IReportBuilder
{
    public IReport Report { get; set; }
    public ReportVisitor Visitor { get; set; }
    
    public EffortReportBuilder(ReportVisitor visitor)
    {
        Visitor = visitor;
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
        if (Visitor != null)
        {
            var backlog = Visitor.Backlog;
            var totalStoryPoints = 0;
            var memberAmount = Visitor.Team.Members.Count;
            var members = "";

            foreach (var item in backlog.BacklogItems)
            {
                var w = item as WorkItem;
                totalStoryPoints += w.StoryPoints;
            }

            var avgStoryPoints = totalStoryPoints / memberAmount;
            
            foreach (var member in Visitor.Team.Members)
            {
                members += $"{member.Name}: {avgStoryPoints} story points\n";
            }
            
            Report.Body = $"This is backlog contains: {backlog.BacklogItems.Count} items with a total of {totalStoryPoints} story points.\n\n" +
                          $"The average amount of story points per member is: {avgStoryPoints}.\n\n" +
                          $"The members and their story points are:\n{members}";
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