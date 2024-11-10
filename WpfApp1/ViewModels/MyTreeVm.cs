using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace WpfApp1.ViewModels;

public interface ITreeVm
{
    List<ITreeItemVm> RootItems { get; }
    ITreeItemVm? SelectedItem { get; set; }
}

public partial class MyTreeVm : ReactiveObject, ITreeVm
{
    public List<ITreeItemVm> RootItems { get;  } = new();

    [Reactive] private ITreeItemVm? _selectedItem;

    public MyTreeVm()
    {
        var item = new TreeItemVm(null, 1,1);
        RootItems.Add(item);
    }
}