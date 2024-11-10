using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModels;

namespace WpfApp1.Views.Controls
{
    public partial class TreeViewControl : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable<ITreeItemVm>), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(ITreeItemVm), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public IEnumerable<ITreeItemVm> ItemsSource
        {
            get => (IEnumerable<ITreeItemVm>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public ITreeItemVm SelectedItem
        {
            get => (ITreeItemVm)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public TreeViewControl()
        {
            InitializeComponent();
        }
    }
} 