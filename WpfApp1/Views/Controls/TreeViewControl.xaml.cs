using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModels;

namespace WpfApp1.Views.Controls
{
    public partial class TreeViewControl : UserControl
    {
        public static readonly DependencyProperty TreeViewModelProperty =
            DependencyProperty.Register(nameof(TreeViewModel), typeof(MyTreeVm), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public MyTreeVm? TreeViewModel
        {
            get => (MyTreeVm)GetValue(TreeViewModelProperty);
            set => SetValue(TreeViewModelProperty, value);
        }

        public TreeViewControl()
        {
            InitializeComponent();
        }
    }
} 