using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BankSystem.ViewModels;

namespace BankSystem.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}