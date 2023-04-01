using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_UnitTest;

public class SprintTest
{
    [Fact]
    public void SprintBacklogAddTest()
    {
        IBacklog sprintBacklog = new SprintBacklog();
        var WorkItem1 = new WorkItem("item 1", "Desc", 3);
        var WorkItem2 = new WorkItem("item 2", "Desc", 3);
        var WorkItem3 = new WorkItem("item 3", "Desc", 3);
        
        sprintBacklog.AddWorkItem(WorkItem1);
        sprintBacklog.AddWorkItem(WorkItem2);
        sprintBacklog.AddWorkItem(WorkItem3);
        
        Assert.Equal(3, sprintBacklog.BacklogItems.Count);
    }
    
    [Fact]
    public void SprintBacklogDeleteTest()
    {
        IBacklog sprintBacklog = new SprintBacklog();
        var WorkItem1 = new WorkItem("item 1", "Desc", 3);
        var WorkItem2 = new WorkItem("item 2", "Desc", 3);
        var WorkItem3 = new WorkItem("item 3", "Desc", 3);
        
        sprintBacklog.AddWorkItem(WorkItem1);
        sprintBacklog.AddWorkItem(WorkItem2);
        sprintBacklog.AddWorkItem(WorkItem3);
        
        sprintBacklog.DeleteWorkItem(WorkItem2);
        
        Assert.Equal(2, sprintBacklog.BacklogItems.Count);
    }
    
    [Fact]
    public void ProductBacklogAddTest()
    {
        IBacklog productBacklog = new ProductBacklog();
        var WorkItem1 = new WorkItem("item 1", "Desc", 3);
        var WorkItem2 = new WorkItem("item 2", "Desc", 3);
        var WorkItem3 = new WorkItem("item 3", "Desc", 3);
        
        productBacklog.AddWorkItem(WorkItem1);
        productBacklog.AddWorkItem(WorkItem2);
        productBacklog.AddWorkItem(WorkItem3);
        
        Assert.Equal(3, productBacklog.BacklogItems.Count);
    }
    
    [Fact]
    public void ProductBacklogDeleteTest()
    {
        IBacklog productBacklog = new ProductBacklog();
        var WorkItem1 = new WorkItem("item 1", "Desc", 3);
        var WorkItem2 = new WorkItem("item 2", "Desc", 3);
        var WorkItem3 = new WorkItem("item 3", "Desc", 3);
        
        productBacklog.AddWorkItem(WorkItem1);
        productBacklog.AddWorkItem(WorkItem2);
        productBacklog.AddWorkItem(WorkItem3);
        
        productBacklog.DeleteWorkItem(WorkItem2);
        
        Assert.Equal(2, productBacklog.BacklogItems.Count);
    }
}