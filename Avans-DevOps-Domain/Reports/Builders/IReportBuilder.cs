using Avans_DevOps_Domain.Reports.Components;

namespace Avans_DevOps_Domain.Reports.Builders;

public interface IReportBuilder
{
    public IReport Report { get; set; }
    public void Reset();
    public void SetHeader();
    public void SetBody();
    public void SetFooter();
    public IReport GetReport();
}