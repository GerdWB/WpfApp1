using System.Collections;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModels;

namespace WpfApp1.Views.Controls
{
    public partial class TreeViewControl : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty ItemsPathProperty =
            DependencyProperty.Register(nameof(ItemsPath), typeof(string), 
                typeof(TreeViewControl), 
                new PropertyMetadata("Children"));

        public static readonly DependencyProperty DisplayPathProperty =
            DependencyProperty.Register(nameof(DisplayPath), typeof(string), 
                typeof(TreeViewControl), 
                new PropertyMetadata("Name"));

        public static readonly DependencyProperty ItemContainerStyleProperty =
            DependencyProperty.Register(nameof(ItemContainerStyle), typeof(Style), 
                typeof(TreeViewControl), 
                new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public string ItemsPath
        {
            get => (string)GetValue(ItemsPathProperty);
            set => SetValue(ItemsPathProperty, value);
        }

        public string DisplayPath
        {
            get => (string)GetValue(DisplayPathProperty);
            set => SetValue(DisplayPathProperty, value);
        }

        public Style ItemContainerStyle
        {
            get => (Style)GetValue(ItemContainerStyleProperty);
            set => SetValue(ItemContainerStyleProperty, value);
        }

        public TreeViewControl()
        {
            InitializeComponent();
        }
    }
} 