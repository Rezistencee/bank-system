using System;
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

    private int _currentAccountIndex;
    private Account _currentAccount;
    private Card _currentCard;
    
    public Client CurrentClient
    {
        get => _currentSession.Client;
    }

    public Account CurrentAccount
    {
        get => _currentAccount;
        private set
        {
            this.RaiseAndSetIfChanged(ref _currentAccount, value);
        }
    }
    
    public Card CurrentCard
    {
        get => _currentCard;
        private set
        {
            this.RaiseAndSetIfChanged(ref _currentCard, value);
        }
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
    public ICommand SwitchAccountToNext { get; }
    public ICommand SwitchAccountToPrevious { get; }
    
    public MainWindowViewModel()
    {
        _clients = new ObservableCollection<Client>();
        
        OpenAdminWindowCommand = ReactiveCommand.Create(OpenAdminWindow);

        _currentAccountIndex = 0;
        _currentSession = SingletonSession.Instance.CurrentSession;

        _currentAccount = _currentSession.Accounts[_currentAccountIndex];
        _currentCard = _currentSession.Cards[_currentAccountIndex];
        
        Console.WriteLine(_currentAccount.Balance);
        
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