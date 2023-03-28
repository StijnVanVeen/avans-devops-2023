using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_UnitTest;

public class ThreadTests
{
    [Fact]
    public void AddCommentToThreadTest()
    {
        //arrange
        TeamMember john = new Developer("John", "Doe");
        Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread("Test Thread", "My test", john);
        Comment comment = new Comment("Test Comment", john);
        
        //act
        thread.Add(comment);
        
        //assert
        Assert.Contains(comment, thread.Children);
    }
    
    [Fact]
    public void AddSubthreadToThreadTest()
    {
        //arrange
        TeamMember john = new Developer("John", "Doe");
        Avans_DevOps_Domain.Forum.Thread thread = new Avans_DevOps_Domain.Forum.Thread("Test Thread", "My test", john);
        Avans_DevOps_Domain.Forum.Thread sub = new Avans_DevOps_Domain.Forum.Thread("Testing Sub","This is a sub thread", john);
        
        //act
        thread.Add(sub);
        
        //assert
        Assert.Contains(sub, thread.Children);
    }}