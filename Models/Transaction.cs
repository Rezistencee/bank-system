using System;

namespace BankSystem.Models
{
    public class Transaction
    {
        public long ID { get; set; }
        public int SourceAccountID { get; set; }
        public int DestinationAccountID { get; set; }
        public int SenderBankID { get; set; }
        public int ReceiverBankID { get; set; }
        public decimal Amount { get; set; }
        public short TransactionsTypeID { get; set; }
        public int PaymentCode { get; set; }
        public string Desctiption { get; set; }

        public Transaction()
        {
            ID = 0;
            SourceAccountID = 0;
            DestinationAccountID = 0;
            SenderBankID = 0;
            ReceiverBankID = 0;
            Amount = 0.0M;
            TransactionsTypeID = 0;
            PaymentCode = 0;
            Desctiption = String.Empty;
        }
    }
}