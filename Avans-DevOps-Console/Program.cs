﻿// See https://aka.ms/new-console-template for more information

using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Project;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Team.Members;

Console.WriteLine("Hello, World!");

var tester = new Tester("Stijn", "email@test.test");

var notifier = new Notifier();
var decorator1 = new EmailNotificationDecorator(notifier);
var decorator2 = new SlackNotificationDecorator(decorator1);
var decorator3 = new TeamsNotificationDecorator(decorator2);
notifier.TeamMember = tester;
var director = new NotificationDirector(decorator3);




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


var Sprint1 = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
Sprint1.Backlog.AddWorkItem(item);
var Sprint2 = new ReleaseSprint("Sprint 2", new DateOnly(2023, 1,15), new DateOnly(2023, 1, 28));

Sprint1.toNextState();
Console.WriteLine(Sprint1.State.Name);

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


