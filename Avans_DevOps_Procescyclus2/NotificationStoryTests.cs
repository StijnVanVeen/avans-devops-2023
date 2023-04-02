using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;
using Moq;

namespace Avans_DevOps_Procescyclus2;

public class NotificationStoryTests
{
    
    /*
     * Notifications
     */
    [Fact]
    public void CanReceive_Notifications()
    {
        // Arrange
        var project = new Project("TestProject");
        var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
        var task = new WorkTask("TestTask", "TestDescription");
        var team = new Team("TestTeam");
        team.AddDeveloper("John Doe", "j.doe@avans.nl");
        var sprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  
        project.Backlog.AddWorkItem(backlogItem);
        backlogItem.AddItem(task);
        project.Team = team;
        project.CurrentSprint = sprint;
  
        // Setting up notifications
        var notifier = new Notifier();
        var email = new EmailNotificationDecorator(notifier);
        var slack = new SlackNotificationDecorator(email);
        var teams = new TeamsNotificationDecorator(slack);
        notifier.TeamMember = team.GetMember("John Doe");
        var director = new Mock<NotificationDirector>();

        // Act
        backlogItem.Publisher.Subscribe(director.Object);
  
        // Assert
        Assert.NotNull(backlogItem.Publisher);
        backlogItem.Publisher.NotifySubscribers();
        director.Verify(x => x.Update(new BacklogItemEventPublisher(backlogItem)), Times.Once);
    }
}