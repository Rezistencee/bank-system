using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BankSystem.Models;

namespace BankSystem.Services.DAL
{
    public class ClientsContext : DatabaseConnection
    {
        private List<Client> _clients;

        public List<Client> Clients
        {
            get
            {
                return _clients;
            }
        }

        public ClientsContext() : base()
        {
            _clients = null;
        }
        
        public void GetClients()
        {
            List<Client> clients = new List<Client>();

            clients.Add(new Client
            {
                Name = "Alex Boost",
                Login = "qwerty123",
                Password = "test",
                ERDPOU = "123543263"
            });

            _clients = clients;
        }

        public Client IsClientExist(string login, string password)
        {
            if(_clients == null)
                GetClients();
            
            return _clients.FirstOrDefault(c => (c.Login == login && c.Password == password));
        }
    }
}