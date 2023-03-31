using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Team;

namespace Avans_DevOps_Domain.Publisher;

public class BacklogItemEventPublisher : IObservable<IItem>
{
    private List<IObserver<IItem>> _observers;
    private IItem item { get; set; }

    public BacklogItemEventPublisher(IItem item)
    {
        this._observers = new List<IObserver<IItem>>();
        this.item = item;
    }

    public IDisposable Subscribe(IObserver<IItem> observer)
    {
        if (! _observers.Contains(observer)) {
            _observers.Add(observer);
            // Provide observer with existing data.
            observer.OnNext(item);
        }
        return new Unsubscriber<IItem>(_observers, observer);
    }

    public void ItemStatus(IItem item)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(item);
        }
    }
}
internal class Unsubscriber<IItem> : IDisposable
{
    private List<IObserver<IItem>> _observers;
    private IObserver<IItem> _observer;

    internal Unsubscriber(List<IObserver<IItem>> observers, IObserver<IItem> observer)
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