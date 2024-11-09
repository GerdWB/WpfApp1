using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using WpfApp1.Services;
namespace WpfApp1.ViewModels;

public partial class Step1ViewModel : StepBaseViewModel
{
    private readonly NavigationService _navigationService;

    private IObservable<bool> _canExecute;
    
    public MyTreeVm Tree { get; }


    [Reactive]
    private string _name = string.Empty;

    public ReactiveCommand<Unit, Unit> NextCommand { get; }

    public Step1ViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        
        Tree = new MyTreeVm();

        // Add property change notifications for debugging
        this.WhenAnyValue(x => x.Name)
            .Subscribe(name => System.Diagnostics.Debug.WriteLine($"Name changed to: {name}"));

        _canExecute = this.WhenAnyValue(
            x => x.Tree.SelectedItem,
            selectedItem => selectedItem is { Children.Count: 0 }
        );

        NextCommand = ReactiveCommand.Create(
            () =>
            {
                var step2 = new Step2ViewModel(_navigationService);
                _navigationService.NavigateTo(step2);
            }, 
            _canExecute);
    }
}