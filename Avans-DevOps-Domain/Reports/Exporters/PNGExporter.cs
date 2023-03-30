using Avans_DevOps_Domain.Reports.Exporters.Result;

namespace Avans_DevOps_Domain.Reports.Exporters;

public class PNGExporter : IExporter
{
    public ExportResult Export(IReport report)
    {
        string FileName = "PNG Report";
        FileType FileType = FileType.PNG;
        string Extension = ".png";
        string FileLocation = $"C:\\Users\\TestUser\\Documents\\{FileName}{Extension}";
        
        string content = report.Header.Text + "\n" + 
                        report.Body + "\n" + 
                        report.Footer.Text + "\n";
        
        Console.WriteLine("Exporting PNG report...");
        Console.WriteLine($"Writing to file {FileLocation}...");
        Console.WriteLine($"Content: \n {content}");
        
        return new ExportResult(FileName, FileType, Extension, FileLocation, content);
    }
}