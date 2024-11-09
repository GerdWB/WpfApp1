using ReactiveUI;
using WpfApp1.ViewModels;

namespace WpfApp1.Services;

public class NavigationService : ReactiveObject
{
    private StepBaseViewModel _currentViewModel = null!;
    public StepBaseViewModel CurrentViewModel 
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    private readonly Stack<StepBaseViewModel> _navigationStack = new();

    public void NavigateTo(StepBaseViewModel viewModel)
    {
        _navigationStack.Push(CurrentViewModel);
        CurrentViewModel = viewModel;
    }

    public void NavigateBack()
    {
        if (_navigationStack.Count > 0)
            CurrentViewModel = _navigationStack.Pop();
    }
}