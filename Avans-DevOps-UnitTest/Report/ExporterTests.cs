using Avans_DevOps_Domain.Reports;
using Avans_DevOps_Domain.Reports.Builders;
using Avans_DevOps_Domain.Reports.Exporters;
using Avans_DevOps_Domain.Reports.Exporters.Result;

namespace Avans_DevOps_UnitTest.Report;

public class ExporterTests
{
    [Fact]
    public void Export_WithPDFExporter_CreatesPDF()
    {
        // Arrange
        var builder = new BurnDownReportBuilder();
        var director = new ReportBuilderDirector(builder);
        var exporter = new PDFExporter();
        
        // Act
        director.MakeReport();
        var report = builder.GetReport();
        var result = exporter.Export(report);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.FileName);
        Assert.NotNull(result.Extension);
        Assert.NotNull(result.FileLocation);
        Assert.NotNull(result.FileContent);
        Assert.Equal( FileType.PDF, result.FileType);
        Assert.Equal(".pdf", result.Extension);
    }
    
    [Fact]
    public void Export_WithPNGExporter_CreatesPNG()
    {
        // Arrange
        var builder = new BurnDownReportBuilder();
        var director = new ReportBuilderDirector(builder);
        var exporter = new PNGExporter();
        
        // Act
        director.MakeReport();
        var report = builder.GetReport();
        var result = exporter.Export(report);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.FileName);
        Assert.NotNull(result.Extension);
        Assert.NotNull(result.FileLocation);
        Assert.NotNull(result.FileContent);
        Assert.Equal( FileType.PNG, result.FileType);
        Assert.Equal(".png", result.Extension);
    }
    
    [Fact]
    public void Export_WithWordExporter_CreatesWord()
    {
        // Arrange
        var builder = new BurnDownReportBuilder();
        var director = new ReportBuilderDirector(builder);
        var exporter = new WordExporter();
        
        // Act
        director.MakeReport();
        var report = builder.GetReport();
        var result = exporter.Export(report);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.FileName);
        Assert.NotNull(result.Extension);
        Assert.NotNull(result.FileLocation);
        Assert.NotNull(result.FileContent);
        Assert.Equal( FileType.WORD_DOCUMENT, result.FileType);
        Assert.Equal(".docx", result.Extension);
    }
}