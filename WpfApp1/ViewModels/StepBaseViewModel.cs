using System.Reactive.Disposables;
using ReactiveUI;

namespace WpfApp1.ViewModels;

public abstract partial class StepBaseViewModel : ReactiveObject, IDisposable
{
    private bool _disposed;
    private readonly CompositeDisposable _disposables = new();

    protected void AddDisposable(IDisposable disposable)
    {
        _disposables.Add(disposable);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _disposables.Dispose();
        }
        _disposed = true;
    }
}