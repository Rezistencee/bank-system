using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BankSystem.ViewModels;

namespace BankSystem.Views;

public partial class AdminWindow : Window
{
    public AdminWindow()
    {
        InitializeComponent();
        DataContext = new AdminWindowViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}