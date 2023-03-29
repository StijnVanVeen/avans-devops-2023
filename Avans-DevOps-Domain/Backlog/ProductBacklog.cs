using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain.Backlog;

public class ProductBacklog : IBacklog
{
    public List<IItem> BacklogItems { get; set; }

    public ProductBacklog()
    {
        BacklogItems = new List<IItem>();
    }

    public void AddWorkItem(IItem item)
    {
        BacklogItems.Add(item);
    }

    public void DeleteWorkItem(IItem item)
    {
        BacklogItems.Remove(item);
    }
}