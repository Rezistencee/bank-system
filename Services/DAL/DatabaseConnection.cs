using System;

namespace BankSystem.Services.DAL
{
    public abstract class DatabaseConnection
    {
        protected readonly string _connectionString = @"Data Source=localhost;Database=Examples;Integrated Security=True;";

        public DatabaseConnection()
        {
            
        }
    }
}