using System;

namespace BankSystem.Models
{
    public class Card
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StatusID { get; set; }

        public Card()
        {
            ID = 0;
            AccountID = 0;
            Number = String.Empty;
            ExpirationDate = DateTime.Now;
            StatusID = 0;
        }
    }
}