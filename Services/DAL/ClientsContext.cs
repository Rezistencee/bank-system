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
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                string query = "SELECT * FROM Clients";
                
                SqlCommand getClientsCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = getClientsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        short clientTypeID = Convert.ToInt16(reader["client_type_id"]);
                        
                        clients.Add(new Client
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString().Trim(),
                            Login = reader["Login"].ToString().Trim(),
                            Password = reader["Password"].ToString().Trim(),
                            ClientTypeID = clientTypeID,
                            ClientType = ClientTypes.FromNumericValue(clientTypeID),
                            EDRPOU = reader["EDRPOU"].ToString(),
                            TelephoneNumber = reader["telephone_number"].ToString(),
                            Address = reader["address"].ToString().Trim(),
                            RegistrationDate = reader.GetDateTime(reader.GetOrdinal("registrationDate"))
                        });
                    }
                }
            }

            _clients = clients;
        }

        public Client IsClientExist(string login, string password) => _clients.FirstOrDefault(c => (c.Login == login && c.Password == password));
    }
}