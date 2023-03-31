using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Forum;

public abstract class ForumComponent
{
    public string Description { get; set; }
    public TeamMember Author { get; set; }
    public ForumComponentEventPublisher Publisher { get; set; }

    public ForumComponent(string description, TeamMember author)
    {
        Publisher = new ForumComponentEventPublisher(this);
        Description = description;
        Author = author;
    }
}