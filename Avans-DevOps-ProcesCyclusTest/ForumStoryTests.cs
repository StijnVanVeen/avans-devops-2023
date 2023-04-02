using Avans_DevOps_Domain.Forums;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_ProcesCyclusTest;

public class ForumStoryTests
{
    [Fact]
    public void CanAdd_Forum_ToProject()
    {
        // Arrange
        var title = "TestProject";
        var project = new Project(title);

        // Assert
        // A project has a forum
        Assert.NotNull(project.Forum);
        Assert.IsType<Forum>(project.Forum);
        Assert.Equal(project.Name, project.Forum.Title);
    }

    [Fact]
    public void CanAdd_Thread_ToForum()
    {
        // Arrange
        var forum = new Forum();
        var user = new Developer("John Doe", "j.doe@avans.nl");
        var thread = new Avans_DevOps_Domain.Forums.Thread("TestThread", "TestDescription", user);

        // Act
        forum.AddThread(thread);

        // Assert
        // A forum has threads
        Assert.NotNull(forum.Threads);
        Assert.Contains(forum.Threads, item => item == thread);
    }

    [Fact]
    public void CanAdd_Comment_ToThread()
    {
        // Arrange
        var project = new Project("TestProject");
        var forum = project.Forum;
        var user = new Developer("John Doe", "j.doe@avans.nl");
        var thread = new Avans_DevOps_Domain.Forums.Thread("TestThread", "TestDescription", user);
        var comment = new Comment("TestComment", user);


        // Act
        forum.AddThread(thread);
        thread.Add(comment);

        // Assert
        // A thread has comments
        Assert.NotNull(thread.Children);
        Assert.Contains(thread.Children, item => item == comment);
    }

    [Fact]
    public void CanAdd_Reply_ToComment()
    {
        // Arrange
        var project = new Project("TestProject");
        var forum = project.Forum;
        var user = new Developer("John Doe", "j.doe@avans.nl");
        var thread = new Avans_DevOps_Domain.Forums.Thread("TestThread", "TestDescription", user);
        var comment = new Comment("TestComment", user);
        var otherUser = new Developer("Jane Doe", "jane.doe@avans.nl");
        var reply = new Comment("TestReply", otherUser);

        // Act
        forum.AddThread(thread);
        thread.Add(comment);
        comment.Add(reply);

        // Assert
        // A comment has replies
        Assert.NotNull(comment.Comments);
        Assert.Contains(comment.Comments, item => item == reply);
    }
}