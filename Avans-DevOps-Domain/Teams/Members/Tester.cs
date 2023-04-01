namespace Avans_DevOps_Domain.Teams.Members;

public class Tester : TeamMember
{
    public Tester(string name, string email) : base(name, email)
    {
        Role = Role.TESTER;
    }
}