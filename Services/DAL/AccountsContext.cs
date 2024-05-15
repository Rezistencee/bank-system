using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankSystem.Models;

namespace BankSystem.Services.DAL;

public class AccountsContext : DatabaseConnection
{
    private List<Account> _accounts;

    public List<Account> Accounts
    {
        get
        {
            return _accounts;
        }
    }

    public AccountsContext() : base()
    {
        _accounts = null;
        GetAccounts();
    }
        
    public void GetAccounts()
    {
        List<Account> accountList = new List<Account>();
            
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = "SELECT * FROM Accounts";
                
            SqlCommand getAccountsCMD = new SqlCommand(query, connection);

            using (SqlDataReader reader = getAccountsCMD.ExecuteReader())
            {
                while (reader.Read())
                {
                    accountList.Add(new Account
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        ClientID = Convert.ToInt32(reader["client_id"]),
                        Balance = Convert.ToDecimal(reader["balance"]),
                        IBAN = reader["IBAN"].ToString(),
                        OpenDate = reader.GetDateTime(reader.GetOrdinal("openDate"))
                    });
                }
            }
        }

        _accounts = accountList;
    }
    
    public List<Account> GetUserAccounts(int userID)
    {
        List<Account> result = new List<Account>();
            
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = 
                """
                SELECT * FROM Accounts
                WHERE client_id = @userID
                """;
                
            SqlCommand getAccountCardsCommand = new SqlCommand(query, connection);

            getAccountCardsCommand.Parameters.AddWithValue("@userID", userID);

            using (SqlDataReader reader = getAccountCardsCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Account
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        ClientID = Convert.ToInt32(reader["client_id"]),
                        Balance = Convert.ToDecimal(reader["balance"]),
                        IBAN = reader["IBAN"].ToString(),
                        OpenDate = reader.GetDateTime(reader.GetOrdinal("openDate"))
                    });
                }
            }
        }

        return result;
    }
}