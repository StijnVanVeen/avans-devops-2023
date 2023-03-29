namespace Avans_DevOps_Domain.Sprints;

public class ReleaseSprintFactory : SprintFactory
{
    public override ISprint CreateSprint(string name, DateOnly startDate, DateOnly endDate)
    {
        return new ReleaseSprint(name, startDate, endDate);
    }
}