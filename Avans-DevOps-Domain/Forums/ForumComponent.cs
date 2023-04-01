using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Forums;

public abstract class ForumComponent
{
    public string Description { get; set; }
    public TeamMember Author { get; set; }

    public ForumComponent(string description, TeamMember author, ForumComponent parent = null)
    {
        Description = description;
        Author = author;
    }
}