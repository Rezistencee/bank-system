using System;
using System.Windows.Input;
using Avalonia.Controls;
using BankSystem.Models;
using BankSystem.Services;
using BankSystem.Services.DAL;
using BankSystem.Views;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class LoginWindowViewModel : ViewModelBase
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

    public LoginWindowViewModel()
    {
        _username = String.Empty;
        _password = String.Empty;
        _clientsContext = new ClientsContext();

        LoginCommand = ReactiveCommand.Create(() =>
        {
            Client currentClient = _clientsContext.IsClientExist(Username, Password);

            if (currentClient != null)
            {
                SingletonSession.Initialize(currentClient);
                
                Window mainWindow = new MainWindow();
                
                mainWindow.Show();
            }
            else
            {
                Console.WriteLine("Incorrect data!");
            }

        });
    }
}