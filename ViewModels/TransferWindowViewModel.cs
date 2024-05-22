using System;
using System.Windows.Input;
using BankSystem.Models;
using BankSystem.Services.DAL;
using ReactiveUI;

namespace BankSystem.ViewModels;

public class TransferWindowViewModel : ViewModelBase
{
    private Account _currentAccount;
    private CardsContext _cardsContext;
    private TransactionsContext _transactionsContext;
    
    private string _cardNumber;
    private decimal _amount;
    private string _errorMessage;
    private string _description;

    public string CardNumber
    {
        get => _cardNumber;
        set => this.RaiseAndSetIfChanged(ref _cardNumber, value);
    }

    public decimal Amount
    {
        get => _amount;
        set => this.RaiseAndSetIfChanged(ref _amount, value);
    }
    
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
    }

    public ICommand TransferCommand { get; }
    
    public TransferWindowViewModel(Account currentAccount)
    {
        _currentAccount = currentAccount;
        _cardsContext = new CardsContext();
        _transactionsContext = new TransactionsContext();

        TransferCommand = ReactiveCommand.Create(ExecuteTransfer);
    }
    
    private void ExecuteTransfer()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(CardNumber))
            {
                ErrorMessage = "Card number is required.";
                return;
            }

            if (Amount <= 0)
            {
                ErrorMessage = "Amount must be greater than zero.";
                return;
            }

            int? receiverID = _cardsContext.GetAccountID(CardNumber);

            if (receiverID is null)
            {
                ErrorMessage = "This card was not found!";
                return;
            }

            _transactionsContext.TransferMoney(_currentAccount.ID, receiverID.Value, Amount, 
                1, 1, Description);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}