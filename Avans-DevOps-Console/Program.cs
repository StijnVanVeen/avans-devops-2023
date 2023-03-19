// See https://aka.ms/new-console-template for more information

using Avans_DevOps_Domain.Items;

Console.WriteLine("Hello, World!");

WorkItem item = new WorkItem("item1", "desc", 1);
item.ChangeStateToDoing();
item.ChangeStateToDone();
