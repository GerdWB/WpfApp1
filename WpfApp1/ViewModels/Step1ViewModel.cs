using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using WpfApp1.Services;
namespace WpfApp1.ViewModels;

public partial class Step1ViewModel : StepBaseViewModel
{
    private readonly NavigationService _navigationService;
    private readonly ILoggingService _loggingService;

    private IObservable<bool> _canExecute;
    
    public MyTreeVm Tree { get; }


    [Reactive]
    private string _name = string.Empty;

    public ReactiveCommand<Unit, Unit> NextCommand { get; }

    public Step1ViewModel(NavigationService navigationService, ILoggingService loggingService)
    {
        _navigationService = navigationService;
        _loggingService = loggingService;
        
        Tree = new MyTreeVm();

        // Log property changes
        this.WhenAnyValue(x => x.Name)
            .Subscribe(name => 
            {
                _loggingService.LogUserAction($"Name updated to: {name}");
                System.Diagnostics.Debug.WriteLine($"Name changed to: {name}");
            });

        _canExecute = this.WhenAnyValue(
            x => x.Tree.SelectedItem,
            selectedItem => 
            {
                var isValid = selectedItem is { Children.Count: 0 };
                _loggingService.LogUserAction($"Selection validity changed: {isValid}");
                return isValid;
            }
        );

        NextCommand = ReactiveCommand.Create(
            () =>
            {
                _loggingService.LogUserAction("Next button clicked");
                var step2 = new Step2ViewModel(_navigationService, _loggingService);
                _navigationService.NavigateTo(step2);
            }, 
            _canExecute);
    }
}