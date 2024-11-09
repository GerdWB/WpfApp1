using System.Reactive;
using ReactiveUI;
using WpfApp1.Services;

namespace WpfApp1.ViewModels;

public class Step3ViewModel(NavigationService navigationService) : StepBaseViewModel
{
    public ReactiveCommand<Unit, Unit> BackCommand { get; } = ReactiveCommand.Create(navigationService.NavigateBack);
}