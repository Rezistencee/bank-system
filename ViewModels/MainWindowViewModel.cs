using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using BankSystem.Models;
using BankSystem.Services;
using BankSystem.Views;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ISession _currentSession;
    
    public Client CurrentClient
    {
        get => _currentSession.Client;
    }
    
    public ICommand OpenAdminWindowCommand { get; }
    
    public MainWindowViewModel()
    {
        OpenAdminWindowCommand = ReactiveCommand.Create(OpenAdminWindow);

        _currentSession = SingletonSession.GetInstance().CurrentSession;
    }

    private void OpenAdminWindow()
    {
        Window adminWindow = new AdminWindow();
        
        adminWindow.Show();
    }
}