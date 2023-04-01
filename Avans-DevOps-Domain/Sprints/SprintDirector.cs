using Avans_DevOps_Domain.Exceptions;
using Avans_DevOps_Domain.Projects;

namespace Avans_DevOps_Domain.Sprints;

public class SprintDirector
{
    public Project Project { get; set; }
    public SprintFactory Factory { get; set; }

    public SprintDirector(Project project)
    {
        Project = project;
        Factory = new ReleaseSprintFactory();
    }

    public void CreateReleaseSprint(string name, DateOnly startDate, DateOnly endDate)
    {
        Factory = new ReleaseSprintFactory();
        var sprint = Factory.CreateSprint(name, startDate, endDate);
        assignSprint(sprint);
    }

    public void CreateReviewSprint(string name, DateOnly startDate, DateOnly endDate)
    {
        Factory = new ReviewSprintFactory();
        var sprint = Factory.CreateSprint(name, startDate, endDate);
        assignSprint(sprint);
    }

    public void NextSprint()
    {
        if (Project.CurrentSprint.State != Project.CurrentSprint.EndState)
            throw new IlligalStateTransitionException();
        Project.PastSprints.AddLast(Project.CurrentSprint);
        Project.CurrentSprint = Project.UpcommingSprints.First();
        Project.UpcommingSprints.RemoveFirst();
    }

    private void assignSprint(ISprint sprint)
    {
        if (Project.CurrentSprint == null)
        {
            Project.CurrentSprint = sprint;
        }
        else
        {
            Project.UpcommingSprints.AddLast(sprint);
        }
    }
}