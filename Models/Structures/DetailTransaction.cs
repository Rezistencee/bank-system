namespace BankSystem.Models.Structures;

public struct DetailTransaction
{
    public int SenderAccountID { get; init; }
    public string Sender { get; init; }
    public string SenderBank { get; init; }
    public string SenderIBAN { get; init; }
    public string Receiver { get; init; }
    public string ReceiverBank { get; init; }
    public string ReceiverIBAN { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; init; }

    public DetailTransaction(string sender, string receiver, decimal amount)
    {
        Sender = sender;
        Receiver = receiver;
        Amount = amount;
    }
}