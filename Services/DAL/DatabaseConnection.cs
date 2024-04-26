using System;

namespace BankSystem.Services.DAL
{
    public abstract class DatabaseConnection
    {
        protected readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Examples";

        public DatabaseConnection()
        {
            
        }
    }
}