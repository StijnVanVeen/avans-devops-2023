using Avans_DevOps_Domain.Reports.Components;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Reports;

public class TeamReport : IReport
{
    public IHeader? Header { get; set; }
    public string? Body { get; set; }
    public IFooter? Footer { get; set; }
}