namespace Avans_DevOps_Domain.Team.Members;

public class ProductOwner : TeamMember
{
    public ProductOwner(string name, string email) : base(name, email)
    {
        Role = Role.PRODUCT_OWNER;
    }
}