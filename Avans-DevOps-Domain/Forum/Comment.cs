using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Forum;

public class Comment : ForumComponent
{
    public ForumComponent Parent { get; set; }
    public List<Comment> Comments { get; set; }
    
    public Comment(string description, TeamMember author) : base(description, author)
    {
        Parent = null;
        Comments = new List<Comment>();
    }
    
    public Comment(string description, TeamMember author, ForumComponent parent) : base(description, author)
    {
        Parent = parent;
        Comments = new List<Comment>();
    }

    public void Add(Comment comment)
    {
        Comments.Add(comment);
    }

    public void Remove(ForumComponent component)
    {
        Comments.Remove((Comment) component);
    }
}