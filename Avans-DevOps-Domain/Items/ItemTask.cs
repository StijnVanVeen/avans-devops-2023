namespace Avans_DevOps_Domain.Items;

public abstract class ItemTask : IItem
{
    public IBacklogItemState TodoState { get; }
    public IBacklogItemState DoingState { get; }
    public IBacklogItemState ReadyForTestingState { get; }
    public IBacklogItemState TestingState { get; }
    public IBacklogItemState TestedState { get; }
    public IBacklogItemState DoneState { get; }
    private string Title { get; set; }
    private string Description { get; set; }
    public IBacklogItemState State { get; set; }
    
    protected ItemTask(string title, string description)
    {
        TodoState = new TodoState(this);
        DoingState = new DoingState(this);
        ReadyForTestingState = new ReadyForTestingstate(this);
        TestingState = new TestingState(this);
        TestedState = new TestedState(this);
        DoneState = new DoneState(this);
        
        Title = title;
        Description = description;
        State = TodoState;
    }
}