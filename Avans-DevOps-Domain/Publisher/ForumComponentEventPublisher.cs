using System.ComponentModel;
using Avans_DevOps_Domain.Forum;
using Avans_DevOps_Domain.Notifications;
using Thread = Avans_DevOps_Domain.Forum.Thread;

namespace Avans_DevOps_Domain.Publisher;

public class ForumComponentEventPublisher : IObservable<ForumComponent>
{
    private List<IObserver<ForumComponent>> _observers;
    private ForumComponent _forumComponent { get; set; }

    public ForumComponentEventPublisher(ForumComponent forumComponent)
    {
        _observers = new List<IObserver<ForumComponent>>();
        _forumComponent = forumComponent;
    }

    public IDisposable Subscribe(IObserver<ForumComponent> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            // Provide observer with existing data.
            observer.OnNext(_forumComponent);
        }

        return new UnsubscriberComment<ForumComponent>(_observers, observer);
    }

    public void ForumComponentStatus(ForumComponent forumComponent)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(forumComponent);
        }
    }
}

internal class UnsubscriberComment<ForumComponent> : IDisposable
{
    private List<IObserver<ForumComponent>> _observers;
    private IObserver<ForumComponent> _observer;

    internal UnsubscriberComment(List<IObserver<ForumComponent>> observers, IObserver<ForumComponent> observer)
    {
        this._observers = observers;
        this._observer = observer;
    }

    public void Dispose()
    {
        if (_observers.Contains(_observer))
            _observers.Remove(_observer);
    }
}