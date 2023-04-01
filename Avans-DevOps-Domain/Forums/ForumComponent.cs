using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Forums;

public abstract class ForumComponent
{
    public string Description { get; set; }
    public TeamMember Author { get; set; }
    public ForumComponent Parent { get; set; }
    
    public ForumComponent(string description, TeamMember author)
    {
        Description = description;
        Author = author;
        Parent = null;
    }

    public ForumComponent(string description, TeamMember author, ForumComponent parent)
    {
        Description = description;
        Author = author;
        Parent = parent;
    }
}