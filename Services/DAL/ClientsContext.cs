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
            GetClients();
        }
        
        public void GetClients()
        {
            List<Client> clients = new List<Client>();

            clients.Add(new Client
            {
                Firstname = "Alex",
                Lastname = "Boost",
                Login = "qwerty123",
                Password = "test",
                ERDPOU = "123543263"
            });
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string query = "SELECT * FROM Clients";
                
                SqlCommand getClientsCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getClientsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            Login = reader["Login"].ToString().Trim(),
                            Password = reader["Password"].ToString().Trim(),
                            ERDPOU = reader["ERDPOU"].ToString()
                        });
                    }
                }
            }

            _clients = clients;
        }

        public Client IsClientExist(string login, string password) => _clients.FirstOrDefault(c => (c.Login == login && c.Password == password));
    }
}