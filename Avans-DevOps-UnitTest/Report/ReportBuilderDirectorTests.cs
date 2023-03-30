using Avans_DevOps_Domain.Reports;
using Avans_DevOps_Domain.Reports.Builders;

namespace Avans_DevOps_UnitTest.Report;

public class ReportBuilderDirectorTests
{
    [Fact]
    public void SetBuilder_SetsBuilder()
    {
        // Arrange
        var builder = new BurnDownReportBuilder();
        var director = new ReportBuilderDirector(builder);
        var newBuilder = new TeamReportBuilder();

        // Act
        director.SetBuilder(newBuilder);

        // Assert
        Assert.Equal(newBuilder, director.Builder);
    }

    [Fact]
    public void MakeReport_WithBurnDownReportBuilder_CreatesBurnDownReport()
    {
        // Arrange
        var builder = new BurnDownReportBuilder();
        var director = new ReportBuilderDirector(builder);

        // Act
        director.MakeReport();
        var report = builder.GetReport();

        // Assert
        Assert.NotNull(report);
        Assert.NotNull(report.Header);
        Assert.NotNull(report.Body);
        Assert.NotNull(report.Footer);
        Assert.IsType<BurnDownReport>(director.Builder.GetReport());
    }
    
    [Fact]
    public void MakeReport_WithEffortReportBuilder_CreatesEffortReport()
    {
        // Arrange
        var builder = new EffortReportBuilder();
        var director = new ReportBuilderDirector(builder);

        // Act
        director.MakeReport();
        var report = builder.GetReport();

        // Assert
        Assert.NotNull(report);
        Assert.NotNull(report.Header);
        Assert.NotNull(report.Body);
        Assert.NotNull(report.Footer);
        Assert.IsType<EffortReport>(director.Builder.GetReport());
    }
    
    [Fact]
    public void MakeReport_WithTeamReportBuilder_CreatesTeamReport()
    {
        // Arrange
        var builder = new TeamReportBuilder();
        var director = new ReportBuilderDirector(builder);

        // Act
        director.MakeReport();
        var report = builder.GetReport();

        // Assert
        Assert.NotNull(report);
        Assert.NotNull(report.Header);
        Assert.NotNull(report.Body);
        Assert.NotNull(report.Footer);
        Assert.IsType<TeamReport>(director.Builder.GetReport());
    }
}