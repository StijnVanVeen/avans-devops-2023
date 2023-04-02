using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_Domain.Items;

public abstract class BacklogItem : IItem
{
    public IBacklogItemState TodoState { get; }
    public IBacklogItemState DoingState { get; }
    public IBacklogItemState ReadyForTestingState { get; }
    public IBacklogItemState TestingState { get; }
    public IBacklogItemState TestedState { get; }
    public IBacklogItemState DoneState { get; }
    public string Title { get; set; }
    public string Description { get; set; }

    private List<IItem> Items { get; set; }
    public IBacklogItemState State { get; set; }
    public BacklogItemEventPublisher Publisher { get; set; }
    public TeamMember? Assignee { get; set; }

    protected BacklogItem(string title, string description)
    {
        TodoState = new TodoState(this);
        DoingState = new DoingState(this);
        ReadyForTestingState = new ReadyForTestingstate(this);
        TestingState = new TestingState(this);
        TestedState = new TestedState(this);
        DoneState = new DoneState(this);
        Publisher = new BacklogItemEventPublisher(this);
        
        Title = title;
        Description = description;
        Items = new List<IItem>();
        State = TodoState;
        Assignee = null;
    }

    public void ChangeStateToToDo()
    {
        State.toToDoState();
        Publisher.ItemStatus(this);
    }
    public void ChangeStateToDoing()
    {
        State.toDoingState();
        Publisher.ItemStatus(this);
    }

    public void ChangeStateToReadyForTesting()
    {
        State.toReadyForTestingState();
        Publisher.ItemStatus(this);
    }

    public void ChangeStateToTesting()
    {
        State.toTestingState();
        Publisher.ItemStatus(this);
    }

    public void ChangeStateToTested()
    {
        State.toTestedState();
        Publisher.ItemStatus(this);
    }

    public void ChangeStateToDone()
    {
        State.toDoneState();
        Publisher.ItemStatus(this);
    }

    public void AddItem(IItem item)
    {
        Items.Add(item);
    }
    public string Operation()
    {
        int i = 0;
        string result = Title + " Branch( ";

        foreach (var item in Items)
        {
            result += item.Operation();
            if (i != Items.Count - 1)
            {
                result += " + ";
            }

            i++;
        }

        return result + " )";
    }
}