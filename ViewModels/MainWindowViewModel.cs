using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private ObservableCollection<Client> _clients;
    private ISession _currentSession;
    
    public Client CurrentClient
    {
        get => _currentSession.Client;
    }

    public ObservableCollection<Client> Clients
    {
        get => _clients;
        set
        {
            _clients = value;
        }
    }
    
    public ICommand OpenAdminWindowCommand { get; }
    
    public MainWindowViewModel()
    {
        _clients = new ObservableCollection<Client>();
        
        OpenAdminWindowCommand = ReactiveCommand.Create(OpenAdminWindow);

        _currentSession = SingletonSession.Instance.CurrentSession;
        
        _clients.Add(new Client
        {
            Name = "Oleksii Khodakovskiy",
            EDRPOU = "362362"
        });
        
        _clients.Add(new Client
        {
            Name = "Andriy Danylov",
            EDRPOU = "362362"
        });
        _clients.Add(new Client
        {
            Name = "Ivan",
            EDRPOU = "362362"
        });
        _clients.Add(new Client
        {
            Name = "Zolik",
            EDRPOU = "362362"
        });
    }

    private void OpenAdminWindow()
    {
        Window adminWindow = new AdminWindow();
        
        adminWindow.Show();
    }
}