namespace Avans_DevOps_Domain;

public interface IBacklogItemState
{
    public void toToDoState();
    public void toDoingState();
    public void toReadyForTestingState();
    public void toTestingState();
    public void toTestedState();
    public void toDoneState();
}