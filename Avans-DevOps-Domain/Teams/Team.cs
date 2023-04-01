using Avans_DevOps_Domain.Teams.Members;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Teams;

public class Team : IVisitable
{
    public List<TeamMember> Members { get; set; }
    public string Name { get; set; }
    public TeamMemberFactoryDirector Director { get; set; }

    public Team(string name)
    {
        Name = name;
        Director = new TeamMemberFactoryDirector();
        Members = new List<TeamMember>();
    }

    public void AddDeveloper(string name, string email)
    {
        Members.Add(Director.CreateDeveloper(name, email));
    }
    
    public void AddScrumMaster(string name, string email)
    {
        Members.Add(Director.CreateScrumMaster(name, email));
    }
    
    public void AddProductOwner(string name, string email)
    {
        Members.Add(Director.CreateProductOwner(name, email));
    }
    
    public void AddTester(string name, string email)
    {
        Members.Add(Director.CreateTester(name, email));
    }
    
    public TeamMember GetMember(string name)
    {
        return Members.FirstOrDefault(member => member.Name == name);
    }

    public void DeleteMember(TeamMember member)
    {
        Members.Remove(member);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitTeam(this);
    }
}