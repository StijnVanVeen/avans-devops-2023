using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Reports;
using Avans_DevOps_Domain.Reports.Builders;
using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_UnitTest.Report;

public class ReportBuilderDirectorTests
{
    [Fact]
    public void SetBuilder_SetsBuilder()
    {
        // Arrange
        var visitor = new ReportVisitor();
        var builder = new BurnDownReportBuilder(visitor);
        var director = new ReportBuilderDirector(builder);
        var newBuilder = new TeamReportBuilder(visitor);

        // Act
        director.SetBuilder(newBuilder);

        // Assert
        Assert.Equal(newBuilder, director.Builder);
    }

    [Fact]
    public void MakeReport_WithBurnDownReportBuilder_CreatesBurnDownReport()
    {
        // Arrange
        var backlog = new SprintBacklog();
        var visitor = new ReportVisitor();
        backlog.Accept(visitor);
        var builder = new BurnDownReportBuilder(visitor);
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
        var backlog = new SprintBacklog();
        var team = new Team("Test Team");
        team.AddTester("John Doe", "j.doe@avans.nl");
        
        var visitor = new ReportVisitor();
        backlog.Accept(visitor);
        team.Accept(visitor);
        
        var builder = new EffortReportBuilder(visitor);
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
        var team = new Team("Test Team");
        team.AddTester("John Doe", "j.doe@avans.nl");
        
        var visitor = new ReportVisitor();
        team.Accept(visitor);
        var builder = new TeamReportBuilder(visitor);
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