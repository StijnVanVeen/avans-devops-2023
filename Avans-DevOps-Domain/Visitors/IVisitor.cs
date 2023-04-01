using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Projects;
using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;

namespace Avans_DevOps_Domain.Visitors;

public interface IVisitor
{
    public void VisitTeam(Team team);
    public void VisitBacklog(IBacklog backlog);
    public void VisitSprint(ISprint sprint);
    public void VisitProject(Project project);
}