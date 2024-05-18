namespace BankSystem.Models.Structures;

public struct DetailTransaction
{
    public string Sender { get; init; }
    public string Receiver { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; init; }

    public DetailTransaction(string sender, string receiver, decimal amount)
    {
        Sender = sender;
        Receiver = receiver;
        Amount = amount;
    }
}