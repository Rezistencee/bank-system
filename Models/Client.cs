using System;

namespace BankSystem.Models
{
    public class Client
    {
        public static int ID { get; private set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ERDPOU { get; set; }

        public Client()
        {
            ID = ID++;
            Name = String.Empty;
            Login = String.Empty;
            Password = String.Empty;
            ERDPOU = String.Empty;
        }
    }
}