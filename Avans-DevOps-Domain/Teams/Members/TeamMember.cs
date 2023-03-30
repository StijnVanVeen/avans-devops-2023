namespace Avans_DevOps_Domain.Team.Members;

public abstract class TeamMember
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    public TeamMember(string name, string email)
    {
        Name = name;
        Email = email;
    }
}