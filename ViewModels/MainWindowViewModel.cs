using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using BankSystem.Views;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand OpenAdminWindowCommand { get; }
    
    public MainWindowViewModel()
    {
        OpenAdminWindowCommand = ReactiveCommand.Create(OpenAdminWindow);
    }

    private void OpenAdminWindow()
    {
        Window adminWindow = new AdminWindow();
        
        adminWindow.Show();
    }
}