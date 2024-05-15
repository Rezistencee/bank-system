using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankSystem.Models;

namespace BankSystem.Services.DAL;

public class TransactionsContext : DatabaseConnection
{
    private List<Transaction> _transactions;

    public List<Transaction> Transactions
    {
        get
        {
            return _transactions;
        }
    }

    public TransactionsContext() : base()
    {
        _transactions = null;
        GetTransactions();
    }
        
    public void GetTransactions()
    {
        List<Transaction> transactionList = new List<Transaction>();
            
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = "SELECT * FROM Transactions;";
                
            SqlCommand getTransactionsCMD = new SqlCommand(query, connection);

            using (SqlDataReader reader = getTransactionsCMD.ExecuteReader())
            {
                while (reader.Read())
                {
                    transactionList.Add(new Transaction
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        SourceAccountID = Convert.ToInt32(reader["source_account"]),
                        DestinationAccountID = Convert.ToInt32(reader["destination_account"]),
                        SenderBankID = Convert.ToInt32(reader["sender_bank_id"]),
                        ReceiverBankID = Convert.ToInt32(reader["receiver_bank_id"]),
                        Amount = Convert.ToDecimal(reader["amount"]),
                        TransactionsTypeID = Convert.ToInt16(reader["transactions_type_id"]),
                        PaymentCode = Convert.ToInt32(reader["payment_code"]),
                        Desctiption = reader["description"].ToString()
                    });
                }
            }
        }

        _transactions = transactionList;
    }
    
    public List<Transaction> GetTransactionAccountList(int accountID)
    {
        List<Transaction> incomeTransactions = new List<Transaction>(10);
            
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = 
                """
                SELECT TOP(10) * FROM Cards
                WHERE destination_account = @accountID OR source_account = @accountID;
                """;
                
            SqlCommand getIncomeTransactions = new SqlCommand(query, connection);

            getIncomeTransactions.Parameters.AddWithValue("@accountID", accountID);

            using (SqlDataReader reader = getIncomeTransactions.ExecuteReader())
            {
                while (reader.Read())
                {
                    incomeTransactions.Add(new Transaction
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        SourceAccountID = Convert.ToInt32(reader["source_account"]),
                        DestinationAccountID = Convert.ToInt32(reader["destination_account"]),
                        SenderBankID = Convert.ToInt32(reader["sender_bank_id"]),
                        ReceiverBankID = Convert.ToInt32(reader["receiver_bank_id"]),
                        Amount = Convert.ToDecimal(reader["amount"]),
                        TransactionsTypeID = Convert.ToInt16(reader["transactions_type_id"]),
                        PaymentCode = Convert.ToInt32(reader["payment_code"]),
                        Desctiption = reader["description"].ToString()
                    });
                }
            }
        }

        return incomeTransactions;
    }
}