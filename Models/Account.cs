using System;
using System.Collections.Generic;
using BankSystem.Models.Structures;

namespace BankSystem.Models
{
    public class Account
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public decimal Balance { get; set; }
        public string IBAN { get; set; }
        public DateTime OpenDate { get; set; }

        public Account()
        {
            ID = 0;
            ClientID = 0;
            Balance = 0.0M;
            IBAN = String.Empty;
            OpenDate = DateTime.Now;
        }
    }
}