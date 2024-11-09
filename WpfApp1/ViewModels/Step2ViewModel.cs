using System.Reactive;
using ReactiveUI;
using WpfApp1.Services;

namespace WpfApp1.ViewModels;

public class Step2ViewModel : StepBaseViewModel
{
    public ReactiveCommand<Unit, Unit> NextCommand { get; }
    public ReactiveCommand<Unit, Unit> BackCommand { get; }

    public Step2ViewModel(NavigationService navigationService)
    {

        // For now, we'll make the Next button always enabled
        NextCommand = ReactiveCommand.Create(() => 
        {
            var step3 = new Step3ViewModel(navigationService);
            navigationService.NavigateTo(step3);
        });

        // Back button is always enabled
        BackCommand = ReactiveCommand.Create(navigationService.NavigateBack);
    }
}