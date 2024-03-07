using System;
using System.Windows;
using System.Windows.Input;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
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

        LoginCommand = ReactiveCommand.Create(() =>
        {
            Console.WriteLine($"Authorized: {Username} {Password}");
        });
    }
}