namespace Avans_DevOps_Domain.Team.Members;

public class Tester : TeamMember
{
    public Tester(string name, string email) : base(name, email)
    {
        Role = Role.TESTER;
    }
}