using System;

namespace BankSystem.Models
{
    public class Client
    {
        public static int ID { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string EDRPOU { get; set; }
        public string Address { get; set; }

        public Client()
        {
            ID = ID++;
            Login = String.Empty;
            Password = String.Empty;
            Name = String.Empty;
            EDRPOU = String.Empty;
            TelephoneNumber = String.Empty;
            Address = String.Empty;
        }
    }
}