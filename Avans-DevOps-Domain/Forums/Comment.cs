using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Forums;

public class Comment : ForumComponent
{
    public ForumComponent? Parent { get; set; }
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
        Console.WriteLine("Adding reply to comment...");
        Comments.Add(comment);
        base.Publisher.ForumComponentStatus(comment);
    }
}