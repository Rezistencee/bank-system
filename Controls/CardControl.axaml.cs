using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace BankSystem.Controls;

public class CardControl : TemplatedControl
{
    public static readonly StyledProperty<string> BalanceProperty =
        AvaloniaProperty.Register<CardControl, string>(nameof(Balance), defaultValue: "00.00");
    
    public static readonly StyledProperty<string> NumberProperty =
        AvaloniaProperty.Register<CardControl, string>(nameof(Number), defaultValue: "XXXX XXXX XXXX XXXX");
    
    public static readonly StyledProperty<string> ExpirationDateProperty =
        AvaloniaProperty.Register<CardControl, string>(nameof(ExpirationDate), defaultValue: "01/24");
    
    public string Balance
    {
        get { return GetValue(BalanceProperty); }
        set { SetValue(BalanceProperty, value); }
    }
    
    public string Number
    {
        get { return GetValue(NumberProperty); }
        set { SetValue(NumberProperty, value); }
    }
    
    public string ExpirationDate
    {
        get { return GetValue(ExpirationDateProperty); }
        set { SetValue(ExpirationDateProperty, value); }
    }
}