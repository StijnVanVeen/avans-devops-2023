using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Reports;
using Avans_DevOps_Domain.Reports.Builders;
using Avans_DevOps_Domain.Reports.Exporters;
using Avans_DevOps_Domain.Reports.Exporters.Result;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Procescyclus2;

public class ReportStoryTests
{
    
/*
 * Reports
 */
 [Fact]
 public void CanAdd_Export_BurnDownReport()
 {
  // Arrange
  var project = new Project("TestProject");
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var task = new WorkTask("TestTask", "TestDescription");
  var team = new Team("TestTeam");
  team.AddDeveloper("John Doe", "j.doe@avans.nl");
  var sprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  
  var visitor = new ReportVisitor();
  var builder = new BurnDownReportBuilder(visitor);
  var director = new ReportBuilderDirector(builder);
  var pdfExporter = new PDFExporter();
  var pngExporter = new PNGExporter();
  var wordExporter = new WordExporter();
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.AddItem(task);
  project.Team = team;
  project.CurrentSprint = sprint;
  sprint.Backlog.AddWorkItem(backlogItem);
  director.MakeReport();
  var report = builder.GetReport();
  
  var pdf = pdfExporter.Export(report);
  var png = pngExporter.Export(report);
  var doc = wordExporter.Export(report);
  
  // Assert
  // A burn down report can be made
  Assert.NotNull(report);
  Assert.IsType<BurnDownReport>(report);

  // A burn down report can be exported to PDF
  Assert.NotNull(pdf);
  Assert.Equal(FileType.PDF, pdf.FileType);
  
  // A burn down report can be exported to PNG
  Assert.NotNull(png);
  Assert.Equal(FileType.PNG, png.FileType);
  
  // A burn down report can be exported to Word
  Assert.NotNull(doc);
  Assert.Equal(FileType.WORD_DOCUMENT, doc.FileType);
 }
 
 [Fact]
 public void CanAdd_Export_EffortReport()
 {
  // Arrange
  var project = new Project("TestProject");
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var task = new WorkTask("TestTask", "TestDescription");
  var team = new Team("TestTeam");
  team.AddDeveloper("John Doe", "j.doe@avans.nl");
  var sprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  
  var visitor = new ReportVisitor();
  var builder = new EffortReportBuilder(visitor);
  var director = new ReportBuilderDirector(builder);
  var pdfExporter = new PDFExporter();
  var pngExporter = new PNGExporter();
  var wordExporter = new WordExporter();
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.AddItem(task);
  project.Team = team;
  project.CurrentSprint = sprint;
  sprint.Backlog.AddWorkItem(backlogItem);
  director.MakeReport();
  var report = builder.GetReport();
  
  var pdf = pdfExporter.Export(report);
  var png = pngExporter.Export(report);
  var doc = wordExporter.Export(report);
  
  // Assert
  // A burn down report can be made
  Assert.NotNull(report);
  Assert.IsType<EffortReport>(report);

  // A burn down report can be exported to PDF
  Assert.NotNull(pdf);
  Assert.Equal(FileType.PDF, pdf.FileType);
  
  // A burn down report can be exported to PNG
  Assert.NotNull(png);
  Assert.Equal(FileType.PNG, png.FileType);
  
  // A burn down report can be exported to Word
  Assert.NotNull(doc);
  Assert.Equal(FileType.WORD_DOCUMENT, doc.FileType);
 }
 
 [Fact]
 public void CanAdd_Export_TeamReport()
 {
  // Arrange
  var project = new Project("TestProject");
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var task = new WorkTask("TestTask", "TestDescription");
  var team = new Team("TestTeam");
  team.AddDeveloper("John Doe", "j.doe@avans.nl");
  var sprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  
  var visitor = new ReportVisitor();
  var builder = new TeamReportBuilder(visitor);
  var director = new ReportBuilderDirector(builder);
  var pdfExporter = new PDFExporter();
  var pngExporter = new PNGExporter();
  var wordExporter = new WordExporter();
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.AddItem(task);
  project.Team = team;
  project.CurrentSprint = sprint;
  sprint.Backlog.AddWorkItem(backlogItem);
  director.MakeReport();
  var report = builder.GetReport();
  
  var pdf = pdfExporter.Export(report);
  var png = pngExporter.Export(report);
  var doc = wordExporter.Export(report);
  
  // Assert
  // A burn down report can be made
  Assert.NotNull(report);
  Assert.IsType<TeamReport>(report);

  // A burn down report can be exported to PDF
  Assert.NotNull(pdf);
  Assert.Equal(FileType.PDF, pdf.FileType);
  
  // A burn down report can be exported to PNG
  Assert.NotNull(png);
  Assert.Equal(FileType.PNG, png.FileType);
  
  // A burn down report can be exported to Word
  Assert.NotNull(doc);
  Assert.Equal(FileType.WORD_DOCUMENT, doc.FileType);
 }
}