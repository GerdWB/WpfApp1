using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveUI;
using WpfApp1.Services;

namespace WpfApp1.ViewModels;

public partial class DebugViewModel : ReactiveObject
{
    private readonly ObservableCollection<string> _logEntries = new();
    public ReadOnlyObservableCollection<string> LogEntries { get; }

    public DebugViewModel(ILoggingService loggingService)
    {
        LogEntries = new ReadOnlyObservableCollection<string>(_logEntries);

        loggingService.LogMessages
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(message => 
            {
                _logEntries.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
                if (_logEntries.Count > 100) // Keep last 100 entries
                {
                    _logEntries.RemoveAt(0);
                }
            });
    }
} 