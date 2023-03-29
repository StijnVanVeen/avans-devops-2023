namespace Avans_DevOps_Domain.Sprints;

public abstract class SprintFactory
{
    public abstract ISprint CreateSprint(string name, DateOnly startDate, DateOnly endDate);
}