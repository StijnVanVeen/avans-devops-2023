using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Backlog;

public interface IBacklog : IVisitable
{
    public List<IItem> BacklogItems { get; set; }
    public void AddWorkItem(IItem item);
    public void DeleteWorkItem(IItem item);
}