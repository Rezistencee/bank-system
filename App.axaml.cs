using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BankSystem.ViewModels;
using BankSystem.Views;

namespace BankSystem;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new LoginWindow
            {
                DataContext = new LoginWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}