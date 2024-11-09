using System.Reactive;
using ReactiveUI;
using WpfApp1.Services;

namespace WpfApp1.ViewModels;

public class Step2ViewModel(NavigationService navigationService, ILoggingService loggingService) : StepBaseViewModel
{

    public ReactiveCommand<Unit, Unit> NextCommand { get; } = ReactiveCommand.Create(() => 
    {
        var step3 = new Step3ViewModel(navigationService);
        navigationService.NavigateTo(step3);
    });

    public ReactiveCommand<Unit, Unit> BackCommand { get; } = ReactiveCommand.Create(navigationService.NavigateBack);
}