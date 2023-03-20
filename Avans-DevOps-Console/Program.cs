// See https://aka.ms/new-console-template for more information

using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Sprints;

Console.WriteLine("Hello, World!");

WorkItem item = new WorkItem("item1", "desc", 1);
item.ChangeStateToDoing();


IItem item2 = new WorkItem("item2", "desc", 1);
IItem item3 = new WorkItem("item3", "desc", 1);

IItem task1 = new WorkTask("task1", "desc");
IItem task2 = new WorkTask("task3", "desc");
IItem task3 = new WorkTask("task3", "desc");

item.AddItem(item2);
item.AddItem(item3);
item.AddItem(task1);
item.AddItem(task2);
item.AddItem(task3);


ISprint Sprint1 = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,1), new DateOnly(2023, 1, 14));
ISprint Sprint2 = new ReleaseSprint("Sprint 1", new DateOnly(2023, 1,15), new DateOnly(2023, 1, 28));

Sprint1.toNextState();
Console.WriteLine(Sprint1.State.Name);