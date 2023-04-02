using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.SprintStates;
using Avans_DevOps_Domain.Teams;

namespace Avans_DevOps_Procescyclus2;

public class SprintStoryTests
{
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
}