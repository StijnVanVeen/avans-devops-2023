using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Backlog;

public class SprintBacklog : IBacklog
{
    public List<IItem> BacklogItems { get; set; }

    public SprintBacklog()
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

    public void Accept(IVisitor visitor)
    {
        visitor.VisitBacklog(this);
    }
}