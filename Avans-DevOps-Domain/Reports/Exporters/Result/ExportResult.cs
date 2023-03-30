namespace Avans_DevOps_Domain.Reports.Exporters.Result;

public class ExportResult
{
    public string FileName { get; set; }
    public FileType FileType { get; set; }
    public string Extension { get; set; }
    public string FileLocation { get; set; }
    public string FileContent { get; set; }
    
    public ExportResult(string fileName, FileType fileType, string extension, string fileLocation, string fileContent)
    {
        FileName = fileName;
        FileType = fileType;
        Extension = extension;
        FileLocation = fileLocation;
        FileContent = fileContent;
    }
}