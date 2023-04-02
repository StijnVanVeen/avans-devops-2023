namespace Avans_DevOps_Domain.Items;

public class WorkItem : BacklogItem
{
    public int StoryPoints
    {
        get
        {
            return StoryPoints;
        }
        set
        {
            if (value < 1)
            {
                StoryPoints = 1;
            }

            StoryPoints = value;
        }
    }
    public WorkItem(string title, string description, int storyPoints) : base(title, description)
    {
        StoryPoints = storyPoints;
    }
}