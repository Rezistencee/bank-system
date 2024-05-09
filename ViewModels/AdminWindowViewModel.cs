using System.Windows.Input;
using Avalonia.Controls;

namespace BankSystem.ViewModels;

public class AdminWindowViewModel : ViewModelBase
{
    private UserControl _currentPage;

    public UserControl CurrentPage
    {
        get => _currentPage;
        set
        {
            if (_currentPage != value)
            {
                _currentPage = value;
            }
        }
    }
    
    public ICommand SwitchPageCommand { get; }

    public AdminWindowViewModel()
    {
        
    }
}