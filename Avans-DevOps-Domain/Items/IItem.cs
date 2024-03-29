﻿using Avans_DevOps_Domain.Publisher;

namespace Avans_DevOps_Domain.Items;

public interface IItem
{
    public IBacklogItemState TodoState { get; }
    public IBacklogItemState DoingState { get; }
    public IBacklogItemState ReadyForTestingState { get; }
    public IBacklogItemState TestingState { get; }
    public IBacklogItemState TestedState { get; }
    public IBacklogItemState DoneState { get; }
    public IBacklogItemState State { get; set; }
    public BacklogItemEventPublisher Publisher { get; set; }
    public  string Title { get; set; }
    public  string Description { get; set; }
    public string Operation();
}