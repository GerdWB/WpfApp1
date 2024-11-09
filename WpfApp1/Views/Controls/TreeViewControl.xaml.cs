using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModels;

namespace WpfApp1.Views.Controls
{
    public partial class TreeViewControl : UserControl
    {
        public static readonly DependencyProperty DisplayPathProperty = 
            DependencyProperty.Register(nameof(DisplayPath), typeof(object), typeof(TreeViewControl), new PropertyMetadata(default(object)));
        public static readonly DependencyProperty ItemsPathProperty = 
            DependencyProperty.Register(nameof(ItemsPath), typeof(object), typeof(TreeViewControl), new PropertyMetadata(default(object)));

        public static readonly DependencyProperty SelectedItemProperty = 
            DependencyProperty.Register(nameof(SelectedItem), typeof(ITreeItemVm), typeof(TreeViewControl), new PropertyMetadata(default(ITreeItemVm?)));

        public static readonly DependencyProperty ItemsSourceProperty = 
            DependencyProperty.Register(nameof(ItemsSource), typeof(List<ITreeItemVm>), typeof(TreeViewControl), new PropertyMetadata(default(List<ITreeItemVm>)));

        public static readonly DependencyProperty TreeViewModelProperty =
            DependencyProperty.Register(nameof(TreeViewModel), typeof(ITreeVm), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public ITreeVm? TreeViewModel
        {
            get => (ITreeVm)GetValue(TreeViewModelProperty);
            set => SetValue(TreeViewModelProperty, value);
        }

        public List<ITreeItemVm> ItemsSource
        {
            get => (List<ITreeItemVm>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public ITreeItemVm? SelectedItem
        {
            get => (ITreeItemVm?)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public object ItemsPath
        {
            get => (object)GetValue(ItemsPathProperty);
            set => SetValue(ItemsPathProperty, value);
        }

        public object DisplayPath
        {
            get => (object)GetValue(DisplayPathProperty);
            set => SetValue(DisplayPathProperty, value);
        }

        public TreeViewControl()
        {
            InitializeComponent();
        }
    }
} 