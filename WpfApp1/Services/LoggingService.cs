using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace WpfApp1.Services;

public interface ILoggingService
{
    IObservable<string> LogMessages { get; }
    void LogNavigation(Type fromViewModel, Type toViewModel);
    void LogUserAction(string action);
}

public partial class LoggingService : ReactiveObject, ILoggingService
{
    private readonly Subject<string> _logMessages = new();
    public IObservable<string> LogMessages => _logMessages.AsObservable();

    [Reactive] private string _lastLogMessage = string.Empty;

    public void LogNavigation(Type fromViewModel, Type toViewModel)
    {
        var message = $"Navigation: {fromViewModel.Name} -> {toViewModel.Name}";
        _lastLogMessage = message;
        _logMessages.OnNext(message);
    }

    public void LogUserAction(string action)
    {
        var message = $"User Action: {action}";
        _lastLogMessage = message;
        _logMessages.OnNext(message);
    }
} 