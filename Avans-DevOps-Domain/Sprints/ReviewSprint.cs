﻿using Avans_DevOps_Domain.Backlog;
using Avans_DevOps_Domain.SprintStates;
using Avans_DevOps_Domain.Visitors;

namespace Avans_DevOps_Domain.Sprints;

public class ReviewSprint : ISprint
{
    public ISprintState InitialState { get; }
    public ISprintState InProgresState { get; }
    public ISprintState FinishedState { get; }
    public ISprintState ReviewState { get; }
    public ISprintState ReleaseState { get; }
    public ISprintState EndState { get; }

    private string _name;
    private DateOnly _startDate;
    private DateOnly _endDate;
    public ISprintState State { get; set; }
    public SprintBacklog Backlog { get; set; }
    public ReviewSprint(string name, DateOnly startDate, DateOnly endDate)
    {
        InitialState = new InitialState(this);
        InProgresState = new InProgresState(this);
        FinishedState = new FinishedState(this);
        ReviewState = new ReviewState(this);
        ReleaseState = new ReleaseState(this);
        EndState = new EndState();
        
        _name = name;
        _startDate = startDate;
        _endDate = endDate;
        State = InitialState;
    }

    public string Name
    {
        get => this._name;
        set
        {
            if (State == InitialState)
            {
                _name = value;
            }
        }
    }
    public DateOnly StartDate
    {
        get => this._startDate;
        set
        {
            if (State == InitialState)
            {
                _startDate = value;
            }
        }
    }
    public DateOnly EndDate
    {
        get => this._endDate;
        set
        {
            if (State == InitialState)
            {
                _endDate = value;
            }
        }
    }

    public void toNextState()
    {
        State.toNextState();
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitSprint(this);
    }
}