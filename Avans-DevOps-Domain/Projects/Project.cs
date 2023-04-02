using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.Forums;
using Avans_DevOps_Domain.Pipelines;
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
    public IBacklog Backlog { get; set; }
    public Forum Forum { get; set; }
    public IPipeline Pipeline { get; set; }
    public SprintDirector SprintDirector { get;}
    public TeamMemberFactoryDirector TeamMemberFactoryDirector { get; set; }
    
    public Project(string name)
    {
        Name = name;
        Team = null;
        PastSprints = new LinkedList<ISprint>();
        UpcommingSprints = new LinkedList<ISprint>();
        CurrentSprint = null;
        Forum = new Forum();
        Forum.Title = Name;
        Backlog = new ProductBacklog();
        Pipeline = null;
        SprintDirector = new SprintDirector(this);
        TeamMemberFactoryDirector = new TeamMemberFactoryDirector(this);
    }

    public Project(string name, Team team)
    {
        Name = name;
        Team = team;
        PastSprints = new LinkedList<ISprint>();
        UpcommingSprints = new LinkedList<ISprint>();
        CurrentSprint = null;
        Forum = new Forum();
        Forum.Title = Name;
        Backlog = new ProductBacklog();
        Pipeline = null;
        SprintDirector = new SprintDirector(this);
        TeamMemberFactoryDirector = new TeamMemberFactoryDirector(this);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitProject(this);
    }
}