using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using BankSystem.Models;
using BankSystem.Models.Structures;
using BankSystem.Services;
using BankSystem.Services.DAL;
using BankSystem.Views;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private TransactionsContext _transactionsContext;
    
    private ObservableCollection<Client> _clients;
    private ObservableCollection<DetailTransaction> _transactions;
    private ISession _currentSession;

    private int _currentAccountIndex;
    private bool _canSwitchToNext;
    private bool _canSwitchToPrevious;
    
    private DetailTransaction _currentSelectableTransaction;
    
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
            LoadTransactions();
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

    public ObservableCollection<DetailTransaction> Transactions
    {
        get => _transactions;
        private set => this.RaiseAndSetIfChanged(ref _transactions, value);
    }
    
    public DetailTransaction CurrentSelectableTransaction
    {
        get => _currentSelectableTransaction;
        set => this.RaiseAndSetIfChanged(ref _currentSelectableTransaction, value);
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
    public ICommand SaveTransactionInformation { get; }
    
    public MainWindowViewModel()
    {
        _transactionsContext = new TransactionsContext();
        
        _clients = new ObservableCollection<Client>();
        _transactions = new ObservableCollection<DetailTransaction>();
        
        OpenAdminWindowCommand = ReactiveCommand.Create(OpenAdminWindow);
        SwitchAccountToPreviousCommand = ReactiveCommand.Create(SwitchAccountToPrevious);
        SwitchAccountToNextCommand = ReactiveCommand.Create(SwitchAccountToNext);
        SaveTransactionInformation = ReactiveCommand.Create(SaveTransactionToFile);
        
        _currentSession = SingletonSession.Instance.CurrentSession;
        _currentAccountIndex = 0;
        
        CurrentAccount = _currentSession.Accounts[_currentAccountIndex];
        CurrentCard = _currentSession.Cards[_currentAccountIndex];
        
        Console.WriteLine(_currentSession.Accounts.Count);
        Console.WriteLine(_currentSession.Cards.Count);
        
        UpdateSwitchAccountCommands();
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

    private void SaveTransactionToFile()
    {
        PDFGenerator.GenerateTransactionFile(CurrentSelectableTransaction);
    }
    
    private void LoadTransactions()
    {
        if (CurrentAccount != null)
        {
            Transactions = new ObservableCollection<DetailTransaction>(
                _transactionsContext.GetLastTenTransactionAccountList(CurrentAccount.ID));
        }
    }
}