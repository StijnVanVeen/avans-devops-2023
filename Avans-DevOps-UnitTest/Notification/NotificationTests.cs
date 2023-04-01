using Avans_DevOps_Domain;
using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Pipelines.Actions;
using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Team.Members;
using Moq;
using Thread = System.Threading.Thread;

namespace Avans_DevOps_UnitTest.Notification;

public class NotificationTests
{
    [Fact]
    public void BacklogItemNotification()
    {
        //assert
        var tester = new Tester("Stijn", "email@test.test");
        var notifier1 = new Notifier(tester);
        var decorator1 = new EmailNotificationDecorator(notifier1);
        var director = new BacklogItemNotificationDirector(decorator1, tester);
        WorkItem item = new WorkItem("Workitem1", "desc", 1);
        item.Publisher.Subscribe(director);
        //act
        item.ChangeStateToDoing();
        //assert
        Assert.Equal(typeof(DoingState), director.item.State.GetType());
        Assert.Equal(tester,director.TeamMember);
        Assert.Equal(decorator1,director.Component);
        Assert.Throws<NotImplementedException>(() => director.OnCompleted());
        Assert.Throws<NotImplementedException>(() => director.OnError(new Exception()));
    }
    [Fact]
    public void PipelineNotification()
    {
        //assert
        var tester = new Tester("Stijn", "email@test.test");
        var notifier1 = new Notifier(tester);
        var decorator1 = new TeamsNotificationDecorator(notifier1);
        var pipeline = new Avans_DevOps_Domain.Pipelines.Pipeline();
        var pipelineDirector = new PipelineNotificationDirector(tester, decorator1);
        pipeline.Publisher.Subscribe(pipelineDirector);
        //act
        pipeline.Execute();
        //assert
        Assert.False(pipelineDirector.Pipeline.LastExecutionSucceeded);
        Assert.Equal(tester, pipelineDirector.TeamMember);
        Assert.Equal(decorator1, pipelineDirector.Component);
        Assert.Throws<NotImplementedException>(() => pipelineDirector.OnCompleted());
        Assert.Throws<NotImplementedException>(() => pipelineDirector.OnError(new Exception()));
    }
    [Fact]
    public void PipelineTrueNotification()
    {
        //assert
        var tester = new Tester("Stijn", "email@test.test");
        var notifier1 = new Notifier(tester);
        var decorator1 = new SlackNotificationDecorator(notifier1);
        var pipeline = new Avans_DevOps_Domain.Pipelines.Pipeline();
        var sourceAction = new SourceAction();
        var pipelineDirector = new PipelineNotificationDirector(tester, decorator1);
        pipeline.Publisher.Subscribe(pipelineDirector);
        pipeline.AddAction(sourceAction);
        //act
        pipeline.Execute();
        //assrt
        Assert.True(pipelineDirector.Pipeline.LastExecutionSucceeded);
        Assert.Equal(tester, pipelineDirector.TeamMember);
        Assert.Equal(decorator1, pipelineDirector.Component);
        Assert.Throws<NotImplementedException>(() => pipelineDirector.OnCompleted());
        Assert.Throws<NotImplementedException>(() => pipelineDirector.OnError(new Exception()));
    }

    [Fact]
    public void ForumNotification()
    {
        var tester = new Tester("Stijn", "email@test.test");
        var notifier1 = new Notifier(tester);
        var decorator1 = new SlackNotificationDecorator(notifier1);
        var forumDirector = new ForumNotificationDirector(tester, decorator1);
        var forum = new Forum();
        var thread = new Avans_DevOps_Domain.Forum.Thread("title", "desc", tester);
        var comment = new Comment("Hoi daar", tester, thread);
        thread.Publisher.Subscribe(forumDirector);
        forum.AddThread(thread);
        
        thread.Add(comment);
        
        Assert.Equal(comment, forumDirector.ForumComponent);
        Assert.Equal(tester, forumDirector.TeamMember);
        Assert.Equal(decorator1, forumDirector.Component);
        Assert.Throws<NotImplementedException>(() => forumDirector.OnCompleted());
        Assert.Throws<NotImplementedException>(() => forumDirector.OnError(new Exception()));
    }
}