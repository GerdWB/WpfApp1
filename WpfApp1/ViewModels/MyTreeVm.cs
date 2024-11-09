using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace WpfApp1.ViewModels;

public partial class MyTreeVm : ReactiveObject
{
    public List<MyTreeItemVm> RootItems { get;  } = new();

    public ReactiveCommand<MyTreeItemVm, Unit> SelectItemCommand { get; }

    [Reactive] private MyTreeItemVm? _selectedItem;

    public MyTreeVm()
    {
        var item = new MyTreeItemVm(null, 1,1);
        RootItems.Add(item);

        SelectItemCommand = ReactiveCommand.Create<MyTreeItemVm>(item => SelectedItem = item);
    }
}