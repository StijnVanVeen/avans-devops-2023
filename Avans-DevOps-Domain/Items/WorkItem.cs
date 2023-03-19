namespace Avans_DevOps_Domain.Items;

public class WorkItem : BacklogItem
{
    public int StoryPoints { get; set; }
    public WorkItem(string title, string description, int storyPoints) : base(title, description)
    {
        StoryPoints = storyPoints;
    }
}