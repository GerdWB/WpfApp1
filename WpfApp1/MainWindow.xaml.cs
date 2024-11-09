using System.Diagnostics;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using ReactiveUI;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1;

public partial class MainWindow : Window
{
    private readonly ILoggingService _loggingService;
    
    public MainWindow()
    {
        InitializeComponent();
        
        _loggingService = new LoggingService();
        var navigationService = new NavigationService(_loggingService);
        DataContext = navigationService;
        
        // Subscribe to log messages for debugging
        _loggingService.LogMessages
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(message => Debug.WriteLine($"[LOG] {message}"));
            
        navigationService.NavigateTo(new Step1ViewModel(navigationService, _loggingService));
    }
}