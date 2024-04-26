using System;

namespace BankSystem.Models
{
    public class Client
    {
        public static int ID { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ERDPOU { get; set; }

        public Client()
        {
            ID = ID++;
            Login = String.Empty;
            Password = String.Empty;
            Firstname = String.Empty;
            Lastname = String.Empty;
            ERDPOU = String.Empty;
        }
    }
}