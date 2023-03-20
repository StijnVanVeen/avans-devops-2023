namespace Avans_DevOps_Domain.Team.Members;

public class ScrumMaster : TeamMember
{
    public ScrumMaster(string name, string email) : base(name, email)
    {
        Role = Role.SCRUM_MASTER;
    }
}