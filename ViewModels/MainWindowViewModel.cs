using System;
using System.Windows.Input;
using BankSystem.Models;
using BankSystem.Services.DAL;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ClientsContext _clientsContext;
    private string _username;
    private string _password;

    public ICommand LoginCommand { get; }
    
    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }

    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
        }
    }

    public MainWindowViewModel()
    {
        _username = String.Empty;
        _password = String.Empty;
        _clientsContext = new ClientsContext();

        LoginCommand = ReactiveCommand.Create(() =>
        {
            Client currentClient = _clientsContext.IsClientExist(Username, Password);
            
            if(currentClient != null)
                Console.WriteLine("Authorized!");
            else
                Console.WriteLine("Incorrect data!");
            
            // TODO: Create new window and open it
        });
    }
}