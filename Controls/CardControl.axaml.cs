using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace BankSystem.Controls;

public class CardControl : TemplatedControl
{
    public static readonly StyledProperty<decimal> BalanceProperty =
        AvaloniaProperty.Register<CardControl, decimal>(nameof(Balance), defaultValue: 0.0M);
    
    public static readonly StyledProperty<string> NumberProperty =
        AvaloniaProperty.Register<CardControl, string>(nameof(Number), defaultValue: "XXXX XXXX XXXX XXXX");
    
    public static readonly StyledProperty<string> ExpirationDateProperty =
        AvaloniaProperty.Register<CardControl, string>(nameof(ExpirationDate), defaultValue: "01/24");
    
    public decimal Balance
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