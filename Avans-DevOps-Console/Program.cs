// See https://aka.ms/new-console-template for more information

using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Pipelines;
using Avans_DevOps_Domain.Pipelines.Actions;
using Avans_DevOps_Domain.Project;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Team;
using Avans_DevOps_Domain.Team.Members;
using Thread = Avans_DevOps_Domain.Forum.Thread;

Console.WriteLine("Hello, World!");

var tester = new Tester("Stijn", "email@test.test");
var developer = new Developer("yannick", "email@test.test");

var notifier1 = new Notifier(tester);
var notifier2 = new Notifier(developer);

var decorator4 = new EmailNotificationDecorator(notifier2);
var decorator1 = new EmailNotificationDecorator(notifier1);
var decorator2 = new SlackNotificationDecorator(decorator1);
var decorator3 = new TeamsNotificationDecorator(decorator2);


var director = new BacklogItemNotificationDirector(decorator3, tester);
var directror2 = new BacklogItemNotificationDirector(decorator4, developer);

WorkItem item = new WorkItem("Workitem1", "desc", 1);
item.Publisher.Subscribe(director);
item.Publisher.Subscribe(directror2);
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


var Sprint1 = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
Sprint1.Backlog.AddWorkItem(item);
var Sprint2 = new ReleaseSprint("Sprint 2", new DateOnly(2023, 1,15), new DateOnly(2023, 1, 28));

Sprint1.toNextState();
Console.WriteLine(Sprint1.State.Name);

var team = new Team("team");

Project project = new Project("test", team);
project.SprintDirector.CreateReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
project.CurrentSprint.Backlog.AddWorkItem(item);
project.SprintDirector.CreateReleaseSprint("Sprint 2", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
Console.WriteLine();


foreach (var itemdsf in project.CurrentSprint.Backlog.BacklogItems)
{
    Console.WriteLine(itemdsf.Operation());
}


var forumDirector = new ForumNotificationDirector(tester, decorator3);
var forumDirector1 = new ForumNotificationDirector(developer, decorator4);

var forum = new Forum();
var thread = new Thread("title", "desc", developer);
var comment = new Comment("Hoi daar", tester, thread);
var countercomment = new Comment("hey jij", developer);
thread.Publisher.Subscribe(forumDirector1);
comment.Publisher.Subscribe(forumDirector);
countercomment.Publisher.Subscribe(forumDirector1);

forum.AddThread(thread);
thread.Add(comment);
comment.Add(countercomment);

var sourceAction = new SourceAction();
var packageAction = new PackageAction();
var buildAction = new BuildAction();
var testAction = new TestAction();
var analyseAction = new AnalyseAction();
var utilityAction = new UtilityAction();
var deployAction = new DeployAction();
        
var pipeline = new Pipeline();

var pipelineDirector = new PipelineNotificationDirector(tester, decorator3);
pipeline.Publisher.Subscribe(pipelineDirector);
pipeline.Execute();

pipeline.AddAction(sourceAction);
pipeline.AddAction(packageAction);
pipeline.AddAction(buildAction);
pipeline.AddAction(testAction);
pipeline.AddAction(analyseAction);
pipeline.AddAction(utilityAction);
pipeline.AddAction(deployAction);

pipeline.Execute();

