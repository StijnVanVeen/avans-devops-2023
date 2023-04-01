using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Items;

public abstract class ItemTask : IItem
{
    public IBacklogItemState TodoState { get; }
    public IBacklogItemState DoingState { get; }
    public IBacklogItemState ReadyForTestingState { get; }
    public IBacklogItemState TestingState { get; }
    public IBacklogItemState TestedState { get; }
    public IBacklogItemState DoneState { get; }
    public IEventPublisher Publisher { get; set; }
    public TeamMember Assignee { get; set; }
    public  string Title { get; set; }
    public  string Description { get; set; }

    public IBacklogItemState State { get; set; }
    
    protected ItemTask(string title, string description)
    {
        TodoState = new TodoState(this);
        DoingState = new DoingState(this);
        ReadyForTestingState = new ReadyForTestingstate(this);
        TestingState = new TestingState(this);
        TestedState = new TestedState(this);
        DoneState = new DoneState(this);
        Publisher = new BacklogItemEventPublisher(this);
        Assignee = null;
        
        Title = title;
        Description = description;
        State = TodoState;
    }
    
    public void ChangeStateToToDo()
    {
        State.toToDoState();
    }
    public void ChangeStateToDoing()
    {
        State.toDoingState();
    }

    public void ChangeStateToReadyForTesting()
    {
        State.toReadyForTestingState();
    }

    public void ChangeStateToTesting()
    {
        State.toTestingState();
    }

    public void ChangeStateToTested()
    {
        State.toTestedState();
    }

    public void ChangeStateToDone()
    {
        State.toDoneState();
    }
    public string Operation()
    {
        return Title;
    }
}