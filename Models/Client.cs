using System;

namespace BankSystem.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public short ClientTypeID { get; set; }
        public ClientTypes ClientType { get; set; }
        public string TelephoneNumber { get; set; }
        public string EDRPOU { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Client()
        {
            ID = ID++;
            Login = String.Empty;
            Password = String.Empty;
            Name = String.Empty;
            ClientTypeID = 0;
            ClientType = ClientTypes.Physical;
            EDRPOU = String.Empty;
            TelephoneNumber = String.Empty;
            Address = String.Empty;
            RegistrationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\nClient type: {1}\nAddress: {2}\nRegistration date: {3}", Name,
                ClientType.Value, Address, RegistrationDate);
        }
    }
}