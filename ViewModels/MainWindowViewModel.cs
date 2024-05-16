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
    private bool _canSwitchToNext;
    private bool _canSwitchToPrevious;
    
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

    public bool CanSwitchNext
    {
        get => _canSwitchToNext;
        private set => this.RaiseAndSetIfChanged(ref _canSwitchToNext, value);
    }

    public bool CanSwitchPrevious
    {
        get => _canSwitchToPrevious;
        private set => this.RaiseAndSetIfChanged(ref _canSwitchToPrevious, value);
    }
    
    public ICommand OpenAdminWindowCommand { get; }
    public ICommand SwitchAccountToNextCommand { get; }
    public ICommand SwitchAccountToPreviousCommand { get; }
    
    public MainWindowViewModel()
    {
        _clients = new ObservableCollection<Client>();
        
        OpenAdminWindowCommand = ReactiveCommand.Create(OpenAdminWindow);
        SwitchAccountToPreviousCommand = ReactiveCommand.Create(SwitchAccountToPrevious);
        SwitchAccountToNextCommand = ReactiveCommand.Create(SwitchAccountToNext);
        
        _currentSession = SingletonSession.Instance.CurrentSession;
        _currentAccountIndex = 0;
        
        CurrentAccount = _currentSession.Accounts[_currentAccountIndex];
        CurrentCard = _currentSession.Cards[_currentAccountIndex];
        
        Console.WriteLine(CurrentCard.Number);
        
        UpdateSwitchAccountCommands();
        
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
    
    private void SwitchAccountToPrevious()
    {
        if (_currentAccountIndex > 0)
        {
            _currentAccountIndex--;
            CurrentAccount = _currentSession.Accounts[_currentAccountIndex];
            CurrentCard = _currentSession.Cards[_currentAccountIndex];
            
            UpdateSwitchAccountCommands();
        }
    }
    
    private void SwitchAccountToNext()
    {
        if (_currentAccountIndex < _currentSession.Accounts.Count - 1)
        {
            _currentAccountIndex++;
            CurrentAccount = _currentSession.Accounts[_currentAccountIndex];
            CurrentCard = _currentSession.Cards[_currentAccountIndex];
            
            UpdateSwitchAccountCommands();
        }
    }
    
    private void UpdateSwitchAccountCommands()
    {
        CanSwitchNext = _currentAccountIndex < _currentSession.Accounts.Count - 1;
        CanSwitchPrevious = _currentAccountIndex > 0;
    }
}