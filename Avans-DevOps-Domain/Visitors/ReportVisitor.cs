using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;


namespace Avans_DevOps_Domain.Visitors;

public class ReportVisitor : IVisitor
{
    public Team Team { get; set; }
    public IBacklog Backlog { get; set; }
    public ISprint Sprint { get; set; }
    public Project Project { get; set; }

    public void VisitTeam(Team team)
    {
        Team = team;
    }
    
    public void VisitBacklog(IBacklog backlog)
    {
        Backlog = backlog;
    }
    
    public void VisitSprint(ISprint sprint)
    {
        Sprint = sprint;
    }
    
    public void VisitProject(Project project)
    {
        Project = project;
    }
}