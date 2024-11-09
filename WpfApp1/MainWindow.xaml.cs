using System.Windows;
using System.Windows.Controls;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Create and set up navigation service
        var navigationService = new NavigationService();
        DataContext = navigationService;
        // Navigate to initial view
        navigationService.NavigateTo(new Step1ViewModel(navigationService));
    }
}