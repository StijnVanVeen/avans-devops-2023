using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Projects;

public class Project : IVisitable
{
    public string Name { get; set; }
    public Team Team { get; set; }
    public LinkedList<ISprint> PastSprints { get;}
    public LinkedList<ISprint> UpcommingSprints { get;}
    public ISprint? CurrentSprint { get; set; }
    public SprintDirector SprintDirector { get;}

    public Project(string name, Team team )
    {
        Name = name;
        Team = team;
        PastSprints = new LinkedList<ISprint>();
        UpcommingSprints = new LinkedList<ISprint>();
        CurrentSprint = null;
        SprintDirector = new SprintDirector(this);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitProject(this);
    }
}