using Avans_DevOps_Domain;
using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_ProcesCyclusTest;

public class BacklogStoryTests
{
    [Fact]
 public void CanAdd_BacklogItems_ToProjectBacklog()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  
  // Assert
  // A project has a backlog
  Assert.NotNull(project.Backlog);
  Assert.IsType<ProductBacklog>(project.Backlog);
  
  // A backlog item can be added to the backlog
  Assert.Contains(project.Backlog.BacklogItems, item => item == backlogItem);
  
  // A backlog item can change state
  Assert.IsType<TodoState>(backlogItem.State);
  backlogItem.ChangeStateToDoing();
  Assert.IsType<DoingState>(backlogItem.State);
  backlogItem.ChangeStateToReadyForTesting();
  Assert.IsType<ReadyForTestingstate>(backlogItem.State);
  backlogItem.ChangeStateToTesting();
  Assert.IsType<TestingState>(backlogItem.State);
  backlogItem.ChangeStateToTested();
  Assert.IsType<TestedState>(backlogItem.State);
  backlogItem.ChangeStateToDone();
  Assert.IsType<DoneState>(backlogItem.State);
 }

 [Fact]
 public void CanAdd_BacklogItems_ToSprintBacklog()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var sprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  
  // Act
  project.CurrentSprint = sprint;
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  project.CurrentSprint.Backlog.AddWorkItem(backlogItem);
  
  // Assert
  // A sprint has a backlog
  Assert.NotNull(project.CurrentSprint.Backlog);
  Assert.IsType<SprintBacklog>(project.CurrentSprint.Backlog);
  
  // A backlog item can be added to the backlog
  Assert.Contains(project.CurrentSprint.Backlog.BacklogItems, item => item == backlogItem);
  }

 [Fact]
 public void CanAdd_Tasks_ToBacklogItem()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var task = new WorkTask("TestTask", "TestDescription");
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.AddItem(task);
  
  // Assert
  // A backlog item can have tasks
  // TODO Assert.Contains(backlogItem.Items, item => item == task);
  
 }
 
 [Fact]
 public void CanAssign_BacklogItem_ToTeamMember()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var name = "John Doe";
  var email = "j.doe@avans.nl";
  var teamMember = new Developer(name, email);
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.Assignee = teamMember;
  
  // Assert
  // A backlog item can be assigned to a team member
  Assert.NotNull(backlogItem.Assignee);
  Assert.Equal(teamMember, backlogItem.Assignee);
 }
 
 [Fact]
 public void CanAssign_Task_ToTeamMember()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var task = new WorkTask("TestTask", "TestDescription");
  var name = "John Doe";
  var email = "j.doe@avans.nl";
  var teamMember = new Developer(name, email);
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.AddItem(task);
  task.Assignee = teamMember;
  
  // Assert
  // A task can be assigned to a team member
  Assert.Equal(teamMember, task.Assignee);
  Assert.Equal(teamMember, task.Assignee);
 }
 
 [Fact]
 public void CanChange_BacklogItem_State()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  
  // Assert
  // A backlog item can change state
  Assert.IsType<TodoState>(backlogItem.State);
  backlogItem.ChangeStateToDoing();
  Assert.IsType<DoingState>(backlogItem.State);
  backlogItem.ChangeStateToReadyForTesting();
  Assert.IsType<ReadyForTestingstate>(backlogItem.State);
  backlogItem.ChangeStateToTesting();
  Assert.IsType<TestingState>(backlogItem.State);
  backlogItem.ChangeStateToTested();
  Assert.IsType<TestedState>(backlogItem.State);
  backlogItem.ChangeStateToDone();
  Assert.IsType<DoneState>(backlogItem.State);
 }
 
 [Fact]
 public void CanChange_Task_State()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  var task = new WorkTask("TestTask", "TestDescription");
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  backlogItem.AddItem(task);
  
  // Assert
  // A task can change state
  Assert.IsType<TodoState>(task.State);
  task.ChangeStateToDoing();
  Assert.IsType<DoingState>(task.State);
  task.ChangeStateToReadyForTesting();
  Assert.IsType<ReadyForTestingstate>(task.State);
  task.ChangeStateToTesting();
  Assert.IsType<TestingState>(task.State);
  task.ChangeStateToTested();
  Assert.IsType<TestedState>(task.State);
  task.ChangeStateToDone();
  Assert.IsType<DoneState>(task.State);
 }
 
 [Fact]
 public void CanAdd_Storypoints_ToBacklogItem()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var backlogItem = new WorkItem("TestBacklogItem", "TestDescription", 1);
  
  // Act
  project.Backlog.AddWorkItem(backlogItem);
  
  // Assert
  // A backlog item can have storypoints
  Assert.Equal(1, backlogItem.StoryPoints);
  
  // A backlog item can change storypoints
  backlogItem.StoryPoints = 2;
  Assert.Equal(2, backlogItem.StoryPoints);
  
 }
}