using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_UnitTest;

public class ThreadTests
{
    private static TeamMember john = new Developer("John Doe", "j.doe@avans.nl");

    [Fact]
    public void AddSubthreadToThreadTest()
    {
        //arrange
        const string title = "Test Thread";
        const string description = "My test";
        var thread = new Avans_DevOps_Domain.Forum.Thread(title, description, john);
        
        const string subTitle = "Testing Sub";
        const string subDescription = "This is a sub thread";
        var sub = new Avans_DevOps_Domain.Forum.Thread(subTitle, subDescription, john, thread);
        
        //act
        thread.Add(sub);
        
        //assert
        Assert.Contains(sub, thread.Children);
        Assert.Equal(thread, sub.Parent);
        
        Assert.Equal(title, thread.Title);
        Assert.Equal(description, thread.Description);
        Assert.Equal(john.Name, thread.Author.Name);
        Assert.Equal(john.Email, thread.Author.Email);
        
        Assert.Equal(subTitle, sub.Title);
        Assert.Equal(subDescription, sub.Description);
        Assert.Equal(john.Name, sub.Author.Name);
        Assert.Equal(john.Email, sub.Author.Email);
    }}