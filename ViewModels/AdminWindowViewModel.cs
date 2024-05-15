using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using BankSystem.Models;
using BankSystem.Services.DAL;
using BankSystem.ViewModels.UserControls;
using Microsoft.Win32;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class AdminWindowViewModel : ViewModelBase
{
    private UserControl _currentPage;
    
    private ClientsContext _clientsContext;
    private TransactionsContext _transactionContext;
    private AccountsContext _accountsContext;
    
    private ObservableCollection<Client> _clients;
    private ObservableCollection<Transaction> _transactions;
    private ObservableCollection<Account> _accounts;
    
    public UserControl CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }
    
    public ObservableCollection<Client> Clients
    {
        get
        {
            return _clients;
        }
        set
        {
            if (_clients != value)
                _clients = value;
        }
    }
    
    public ObservableCollection<Transaction> Transactions
    {
        get
        {
            return _transactions;
        }
        set
        {
            if (_transactions != value)
                _transactions = value;
        }
    }
    
    public ObservableCollection<Account> Accounts
    {
        get
        {
            return _accounts;
        }
        set
        {
            if (_accounts != value)
                _accounts = value;
        }
    }
    
    public ReactiveCommand<object, Unit> SwitchPageCommand { get; }


    public AdminWindowViewModel()
    {
        _clientsContext = new ClientsContext();
        _transactionContext = new TransactionsContext();
        _accountsContext = new AccountsContext();
        
        Clients = new ObservableCollection<Client>(_clientsContext.Clients);
        Transactions = new ObservableCollection<Transaction>(_transactionContext.Transactions);
        Accounts = new ObservableCollection<Account>(_accountsContext.Accounts);

        SwitchPageCommand = ReactiveCommand.Create<object>(SwitchPage);
        
        _currentPage = new ClientsPage() { DataContext = this } ;
    }

    public void SwitchPage(object sender)
    {
        string content = sender as string;

        switch (content)
        {
            case "Clients" :
            {
                CurrentPage = new ClientsPage() { DataContext = this };
                break;
            }
            case "Transactions":
            {
                CurrentPage = new TransactionsPage() { DataContext = this };
                break;
            }
            case "Accounts":
            {
                CurrentPage = new AccountsPage() { DataContext = this };
                break;
            }
        }
    }
}