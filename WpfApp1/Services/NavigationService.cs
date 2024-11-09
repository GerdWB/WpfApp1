using ReactiveUI;
using ReactiveUI.SourceGenerators;
using WpfApp1.ViewModels;

namespace WpfApp1.Services;

public partial class NavigationService : ReactiveObject
{
    private readonly ILoggingService _loggingService;

    [Reactive] private StepBaseViewModel _currentViewModel = null!;
        
    private readonly Stack<StepBaseViewModel> _navigationStack = new();

    public NavigationService(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    public void NavigateTo(StepBaseViewModel viewModel)
    {
        var previousType = CurrentViewModel?.GetType();
        _navigationStack.Push(CurrentViewModel);
        CurrentViewModel = viewModel;
        
        if (previousType != null)
        {
            _loggingService.LogNavigation(previousType, viewModel.GetType());
        }
    }

    public void NavigateBack()
    {
        if (_navigationStack.Count > 0)
        {
            var previousType = CurrentViewModel.GetType();
            CurrentViewModel = _navigationStack.Pop();
            _loggingService.LogNavigation(previousType, CurrentViewModel.GetType());
        }
    }

    public bool CanNavigateBack => _navigationStack.Count > 0;

    [ObservableAsProperty] public bool HasNavigationHistory { get; }
}