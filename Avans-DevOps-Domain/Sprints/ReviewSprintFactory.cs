namespace Avans_DevOps_Domain.Sprints;

public class ReviewSprintFactory : SprintFactory
{
    public override ISprint CreateSprint(string name, DateOnly startDate, DateOnly endDate)
    {
        return new ReviewSprint(name, startDate, endDate);
    }
}