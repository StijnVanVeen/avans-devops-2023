using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_UnitTest;

public class CommentTests
{
    [Fact]
    public void AddCommentToThreadTest()
    {
        //arrange
        TeamMember john = new Developer("John", "Doe");
        Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread("Test Thread", "My test", john);
        Comment comment = new Comment("Test Comment", john);
        TeamMember jane = new Developer("Jane", "Doe");
        Comment reply = new Comment("A reply", jane);
        
        //act
        comment.Add(reply);
        
        //assert
        Assert.Contains(reply, comment.Comments);
    }
    
    
}