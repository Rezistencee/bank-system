using System;

namespace BankSystem.Models
{
    public class Bank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MFO { get; set; }
        public string Address { get; set; }

        public Bank()
        {
            ID = 0;
            Name = String.Empty;
            MFO = String.Empty;
            Address = String.Empty;
        }
    }
}