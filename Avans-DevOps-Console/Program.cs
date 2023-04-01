using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Teams.Members;
using Avans_DevOps_Domain.Visitors;
using Avans_DevOps_Domain.Reports;
using Avans_DevOps_Domain.Reports.Builders;
using Avans_DevOps_Domain.Reports.Exporters;

Console.WriteLine("Avans DevOps");

// Setting up teams and team members
var team = new Team("Testers");
var name = "Stijn van Veen";
var email = "s.vanveen@avans.nl";
team.AddTester(name, email);
var tester = team.GetMember(name);

// Setting up notifications
var notifier = new Notifier();
var decorator1 = new EmailNotificationDecorator(notifier);
var decorator2 = new SlackNotificationDecorator(decorator1);
var decorator3 = new TeamsNotificationDecorator(decorator2);
notifier.TeamMember = tester;
var director = new NotificationDirector(decorator3);

// Setting up work items and tasks
WorkItem item = new WorkItem("Workitem1", "desc", 1);
item.Publisher.Subscribe(director);
item.ChangeStateToDoing();
item.ChangeStateToReadyForTesting();

var item2 = new WorkItem("Workitem2", "desc", 1);
var item3 = new WorkItem("Workitem3", "desc", 1);

var task1 = new WorkTask("task1", "desc");
var task2 = new WorkTask("task3", "desc");
var task3 = new WorkTask("task3", "desc");
var task4 = new WorkTask("task4", "desc");
var task5 = new WorkTask("task5", "desc");
var task6 = new WorkTask("task6", "desc");

item3.AddItem(task4);
item3.AddItem(task5);
item2.AddItem(task6);

item.AddItem(item2);
item.AddItem(item3);
item.AddItem(task1);
item.AddItem(task2);
item.AddItem(task3);

// Setting up sprints
var Sprint1 = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
Sprint1.Backlog.AddWorkItem(item);
var Sprint2 = new ReleaseSprint("Sprint 2", new DateOnly(2023, 1,15), new DateOnly(2023, 1, 28));

Sprint1.toNextState();
Console.WriteLine(Sprint1.State.Name);

// Setting up project
Project project = new Project("test", null);
project.SprintDirector.CreateReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
project.CurrentSprint.Backlog.AddWorkItem(item);
project.SprintDirector.CreateReleaseSprint("Sprint 2", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
//project.SprintDirector.NextSprint();
Console.WriteLine();

foreach (var itemdsf in project.CurrentSprint.Backlog.BacklogItems)
{
    Console.WriteLine(itemdsf.Operation());
}

// Generating reports
var reportVisitor = new ReportVisitor();

project.Accept(reportVisitor);
Sprint1.Accept(reportVisitor);
Sprint2.Accept(reportVisitor);
Sprint1.Backlog.Accept(reportVisitor);
Sprint2.Backlog.Accept(reportVisitor);
team.Accept(reportVisitor);

var reportBuilder = new TeamReportBuilder(reportVisitor);
var reportDirector = new ReportBuilderDirector(reportBuilder);

reportDirector.MakeReport();

var report = reportBuilder.GetReport();

// Exporting reports
var exporter = new WordExporter();
exporter.Export(report);


