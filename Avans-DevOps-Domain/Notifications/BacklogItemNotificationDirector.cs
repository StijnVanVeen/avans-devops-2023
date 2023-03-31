﻿using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Publisher;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_Domain.Notifications;

public class BacklogItemNotificationDirector : IObserver<IItem>, ISubscriber
{
    public TeamMember TeamMember { get; set; }
    public IDecoratorComponent Component { get; set; }

    public IItem? item { get; set; }

    private IDisposable cancellation;

    public BacklogItemNotificationDirector(IDecoratorComponent component, TeamMember teamMember)
    {
        Component = component;
        TeamMember = teamMember;
    }
    
    public virtual void Subscribe(BacklogItemEventPublisher provider)
    {
        cancellation = provider.Subscribe(this);
    }

    public virtual void Unsubscribe()
    {
        cancellation.Dispose();
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(IItem value)
    {
        Component.Send("to " + TeamMember.Name + ": " +value.Title + " has moved to " + value.State.toString());
    }
}