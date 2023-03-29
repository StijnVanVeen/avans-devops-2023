using Avans_DevOps_Domain.Items;

namespace Avans_DevOps_Domain.Backlog;

public interface IBacklog
{
    public List<IItem> BacklogItems { get; set; }
    public void AddWorkItem(IItem item);
    public void DeleteWorkItem(IItem item);
}