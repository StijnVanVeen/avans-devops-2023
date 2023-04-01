using Avans_DevOps_Domain.Items;
using Avans_DevOps_Domain.Notifications;
using Avans_DevOps_Domain.Pipelines;

namespace Avans_DevOps_Domain.Publisher;

public class PipelineEventPublisher : IObservable<IPipeline>
{
    private List<IObserver<IPipeline>> _observers;
    private IPipeline pipeline { get; set; }

    public PipelineEventPublisher(IPipeline pipeline)
    {
        this._observers = new List<IObserver<IPipeline>>();
        this.pipeline = pipeline;
    }

    public IDisposable Subscribe(IObserver<IPipeline> observer)
    {
        if (! _observers.Contains(observer)) {
            _observers.Add(observer);
            // Provide observer with existing data.
            observer.OnNext(pipeline);
        }
        return new UnsubscriberPipeline<IPipeline>(_observers, observer);
    }

    public void PipelineStatus(IPipeline pipeline)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(pipeline);
        }
    }
}

internal class UnsubscriberPipeline<IPipeline> : IDisposable
{
    private List<IObserver<IPipeline>> _observers;
    private IObserver<IPipeline> _observer;

    internal UnsubscriberPipeline(List<IObserver<IPipeline>> observers, IObserver<IPipeline> observer)
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
