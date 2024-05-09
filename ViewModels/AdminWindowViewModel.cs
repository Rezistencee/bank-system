using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using BankSystem.Models;
using BankSystem.ViewModels.UserControls;
using Microsoft.Win32;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class AdminWindowViewModel : ViewModelBase
{
    private UserControl _currentPage;

    private ObservableCollection<Client> _clients;
    
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
    
    public ReactiveCommand<object, Unit> SwitchPageCommand { get; }


    public AdminWindowViewModel()
    {
        Clients = new ObservableCollection<Client>();

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
        }
    }
}