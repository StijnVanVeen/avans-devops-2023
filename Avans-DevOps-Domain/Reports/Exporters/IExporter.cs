using Avans_DevOps_Domain.Reports.Exporters.Result;

namespace Avans_DevOps_Domain.Reports.Exporters;

public interface IExporter
{
    public ExportResult Export(IReport report);
}