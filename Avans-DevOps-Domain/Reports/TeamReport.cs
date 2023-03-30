using Avans_DevOps_Domain.Reports.Components;

namespace Avans_DevOps_Domain.Reports;

public class TeamReport : IReport
{
    public IHeader Header { get; set; }
    public string Body { get; set; }
    public IFooter Footer { get; set; }
}