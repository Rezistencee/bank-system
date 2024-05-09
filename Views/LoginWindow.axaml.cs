using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BankSystem.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}