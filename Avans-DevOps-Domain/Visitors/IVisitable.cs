namespace Avans_DevOps_Domain.Visitors;

public interface IVisitable
{
    public void Accept(IVisitor visitor);
}