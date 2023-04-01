using Avans_DevOps_Domain;
using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Forums;
using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.SprintStates;
using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_ProcesCyclusTest;

public class ProjectCyclusTest
{
 /*
  * Projects
  */
 [Fact]
 public void CanAdd_Project()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var team = new Team("TestTeam");

  // Act
  project.Team = team;

  // Assert
  // A project can be made
  Assert.NotNull(project);

  // A project has a name
  Assert.NotNull(project.Name);
  Assert.Equal(title, project.Name);

  // A project has a team
  Assert.NotNull(project.Team);
  Assert.Equal(team, project.Team);
 }

 /*
  * Sprints
  */
 [Fact]
 public void CanAdd_Sprint_ToProject()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var team = new Team("TestTeam");
  var pastSprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue); 
  var currentSprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  var futureSprint = new ReviewSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);

  // Act
  project.Team = team;
  project.CurrentSprint = currentSprint;
  project.PastSprints.AddLast(pastSprint);
  project.UpcommingSprints.AddLast(futureSprint);

  // Assert
  // A sprint can be made
  Assert.NotNull(currentSprint);
 
  // A sprint has a start- and end date
  Assert.NotNull(currentSprint.StartDate);
  Assert.NotNull(currentSprint.EndDate);
 
  // A sprint has a certain state
  Assert.Contains(project.PastSprints, sprint => sprint == pastSprint);
  Assert.NotNull(currentSprint);
  Assert.Contains(project.UpcommingSprints, sprint => sprint == futureSprint);
 
  // A sprint in in a certain stage
  // Release sprint
  Assert.IsType<InitialState>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<InProgresState>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<FinishedState>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<ReleaseSprint>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<EndState>(currentSprint.State);
 
  // Review sprint
  Assert.IsType<InitialState>(futureSprint.State);
  futureSprint.toNextState();
  Assert.IsType<InProgresState>(futureSprint.State);
  futureSprint.toNextState();
  Assert.IsType<FinishedState>(futureSprint.State);
  futureSprint.toNextState();
 Assert.IsType<ReviewState>(futureSprint.State);
 futureSprint.toNextState();
 Assert.IsType<EndState>(futureSprint.State);
 
 // A sprint has a certain type
 Assert.IsType<ReleaseSprint>(currentSprint);
 Assert.IsType<ReviewSprint>(futureSprint);
 }

 [Fact]
 public void CanChange_SprintState()
 {
  // Arrange
  var currentSprint = new ReleaseSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  var futureSprint = new ReviewSprint("TestSprint", DateOnly.MinValue, DateOnly.MaxValue);
  
  // Act
  
  // Assert
  // A sprint in in a certain stage
  // Release sprint
  Assert.IsType<InitialState>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<InProgresState>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<FinishedState>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<ReleaseSprint>(currentSprint.State);
  currentSprint.toNextState();
  Assert.IsType<EndState>(currentSprint.State);
 
  // Review sprint
  Assert.IsType<InitialState>(futureSprint.State);
  futureSprint.toNextState();
  Assert.IsType<InProgresState>(futureSprint.State);
  futureSprint.toNextState();
  Assert.IsType<FinishedState>(futureSprint.State);
  futureSprint.toNextState();
  Assert.IsType<ReviewState>(futureSprint.State);
  futureSprint.toNextState();
  Assert.IsType<EndState>(futureSprint.State);
 }
 
 /*
  * Teams
  */
 [Fact]
 public void CanAdd_Member_ToTeam()
 {
  // Arrange
  var title = "TestProject";
  var project = new Project(title);
  var team = new Team("TestTeam");
  var name = "John Doe";
  var email = "j.doe@avans.nl";
  
  // Act
  project.Team = team;
  project.Team.AddDeveloper(name, email);
  project.Team.AddProductOwner(name, email);
  project.Team.AddScrumMaster(name, email);
  project.Team.AddTester(name, email);
  
  // Assert
  // Developer can be added to team
  Assert.Contains(team.Members, member => member.Role == Role.DEVELOPER);
  
  // Product owner can be added to team
  Assert.Contains(team.Members, member => member.Role == Role.PRODUCT_OWNER);
  
  // Product owner can only be added once
  Assert.Single(team.Members, member => member.Role == Role.PRODUCT_OWNER);
  Assert.Throws<IllegalTeamMemberCreationException>(() => project.Team.AddProductOwner(name, email));
  
  // Scrum master can be added to team
  Assert.Contains(team.Members, member => member.Role == Role.SCRUM_MASTER);
  
  // Scrum master can only be added once
  Assert.Single(team.Members, member => member.Role == Role.SCRUM_MASTER);
  Assert.Throws<IllegalTeamMemberCreationException>(() => project.Team.AddScrumMaster(name, email));
  
  // Tester can be added to team
  Assert.Contains(team.Members, member => member.Role == Role.TESTER);
 }

 /*
  * Backlog
  */
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
  backlogItem.ChangeStateToDone();
  Assert.IsType<DoneState>(backlogItem.State);
  backlogItem.ChangeStateToReadyForTesting();
  Assert.IsType<ReadyForTestingstate>(backlogItem.State);
  backlogItem.ChangeStateToTesting();
  Assert.IsType<TestingState>(backlogItem.State);
  backlogItem.ChangeStateToTested();
  Assert.IsType<TestedState>(backlogItem.State);
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
  
  //TODO: What kind of task does a Sprint BacklogItem have?
  //Assert.Contains(backlogItem., item => item == task);

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
  
 }
 
 [Fact]
 public void CanChange_Task_State()
 {
  
 }
 
 [Fact]
 public void CanAdd_Storypoints_ToBacklogItem()
 {
  
 }

 /*
  * Forums
  */
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
  Assert.Equal(thread, comment.Parent);
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
  Assert.Equal(comment, reply.Parent);
 }

/*
 * Reports
 */

 /*
  * Pipelines
  */
 
 /*
  * Notifications
  */
 
}