using Avans_DevOps_Domain.Reports.Exporters.Result;

namespace Avans_DevOps_Domain.Reports.Exporters;

public class WordExporter : IExporter
{
    public ExportResult Export(IReport report)
    {
        string FileName = "Word Report";
        FileType FileType = FileType.WORD_DOCUMENT;
        string Extension = ".docx";
        string FileLocation = $"C:\\Users\\TestUser\\Documents\\{FileName}{Extension}";
        
        string content = report.Header.Text + "\n" + 
                        report.Body + "\n" + 
                        report.Footer.Text + "\n";
        
        Console.WriteLine("Exporting Word report...");
        Console.WriteLine($"Writing to file {FileLocation}...");
        Console.WriteLine($"Content: \n {content}");
        
        return new ExportResult(FileName, FileType, Extension, FileLocation, content);
    }
}