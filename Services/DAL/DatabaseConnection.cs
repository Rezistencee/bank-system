using System;

namespace BankSystem.Services.DAL
{
    public abstract class DatabaseConnection
    {
        protected static string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = String.Empty;
        }

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}