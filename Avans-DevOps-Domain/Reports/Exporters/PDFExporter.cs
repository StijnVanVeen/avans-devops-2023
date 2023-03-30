using Avans_DevOps_Domain.Reports.Exporters.Result;

namespace Avans_DevOps_Domain.Reports.Exporters;

public class PDFExporter : IExporter
{
    public ExportResult Export(IReport report)
    {
        string FileName = "PDF Report";
        FileType FileType = FileType.PDF;
        string Extension = ".pdf";
        string FileLocation = $"C:\\Users\\TestUser\\Documents\\{FileName}{Extension}";
        
        string content = report.Header.Text + "\n" + 
                        report.Body + "\n" + 
                        report.Footer.Text + "\n";

        Console.WriteLine("Exporting PDF report...");
        Console.WriteLine($"Writing to file {FileLocation}...");
        Console.WriteLine($"Content: \n {content}");
        
        return new ExportResult(FileName, FileType, Extension, FileLocation, content);
    }
}