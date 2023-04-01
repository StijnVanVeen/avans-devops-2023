namespace Avans_DevOps_Domain.Teams.Members;

public class Developer : TeamMember
{
    public Developer(string name, string email) : base(name, email)
    {
        Role = Role.DEVELOPER;
    }
}