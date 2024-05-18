using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BankSystem.Models;
using BankSystem.Models.Structures;

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
    
    public List<DetailTransaction> GetLastTenTransactionAccountList(int accountID)
    {
        List<DetailTransaction> incomeTransactions = new List<DetailTransaction>();
            
        Console.WriteLine($"Fetching last ten transactions for account ID: {accountID}");
        
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = 
                """
                SELECT TOP 10 
                   senderClient.name AS Sender, 
                   receiverClient.name AS Receiver, 
                                       t.amount ,
                                       t.Description AS Description
                                   FROM Transactions t
                                   JOIN Accounts senderAccount ON t.source_account = senderAccount.ID
                                   JOIN Clients senderClient ON senderAccount.client_id = senderClient.ID
                                   JOIN Accounts receiverAccount ON t.destination_account = receiverAccount.ID
                                   JOIN Clients receiverClient ON receiverAccount.client_id = receiverClient.ID
                                   WHERE t.source_account = @AccountId OR t.destination_account = @AccountId
                                   ORDER BY t.ID DESC
                """;
                
            SqlCommand getIncomeTransactions = new SqlCommand(query, connection);

            getIncomeTransactions.Parameters.AddWithValue("@AccountId", accountID);

            using (SqlDataReader reader = getIncomeTransactions.ExecuteReader())
            {
                while (reader.Read())
                {
                    incomeTransactions.Add(new DetailTransaction
                    {
                        Receiver = reader["Receiver"].ToString(),
                        Sender = reader["Sender"].ToString(),
                        Amount = (decimal)reader["Amount"],
                        Description = reader["Description"].ToString().Trim()
                    });
                }
            }
        }

        return incomeTransactions;
    }
}