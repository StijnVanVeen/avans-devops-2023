using Avans_DevOps_Domain.Sprints;
using Avans_DevOps_Domain.Team;

namespace Avans_DevOps_Domain.Project;

public class Project
{
    public string Name { get; set; }
    public Team.Team Team { get; set; }
    public LinkedList<ISprint> PastSprints { get;}
    public LinkedList<ISprint> UpcommingSprints { get;}
    public ISprint? CurrentSprint { get; set; }
    public SprintDirector SprintDirector { get;}

    public Project(string name, Team.Team team )
    {
        Name = name;
        Team = team;
        PastSprints = new LinkedList<ISprint>();
        UpcommingSprints = new LinkedList<ISprint>();
        CurrentSprint = null;
        SprintDirector = new SprintDirector(this);
    }
}