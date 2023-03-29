using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_UnitTest;

public class CommentTests
{
    private static readonly TeamMember john = new Developer("John Doe", "j.doe@avans.nl");

    private const string title = "Test Thread";
    private const string description = "My test";
    private static readonly Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread(title, description, john);
    
    [Fact]
    public void AddCommentToThreadTest()
    {
        //arrange
        const string message = "Test Comment";
        var comment = new Comment(message, john, thread);

        //act
        thread.Add(comment);

        //assert
        Assert.Contains(comment, thread.Children);
        Assert.Equal(thread, comment.Parent);
        
        Assert.Equal(john.Name, comment.Author.Name);
        Assert.Equal(john.Email, comment.Author.Email);
        Assert.Equal(message, comment.Description);
    }

    [Fact]
    public void AddReplyToCommentTest()
    {
        //arrange
        const string message = "Test Comment";
        var comment = new Comment(message, john, thread);
        
        TeamMember jane = new Developer("Jane", "jane.doe@avans.nl");
        const string replyMessage = "Test Reply";
        var reply = new Comment(replyMessage, jane, comment);

        //act
        thread.Add(comment);
        comment.Add(reply);

        //assert
        Assert.Contains(comment, thread.Children);
        Assert.Equal(thread, comment.Parent);
        Assert.Contains(reply, comment.Comments);
        Assert.Equal(comment, reply.Parent);

        Assert.Equal(john.Name, comment.Author.Name);
        Assert.Equal(john.Email, comment.Author.Email);
        Assert.Equal(message, comment.Description);
        
        Assert.Equal(jane.Name, reply.Author.Name);
        Assert.Equal(jane.Email, reply.Author.Email);
        Assert.Equal(replyMessage, reply.Description);
    }
    
    
}