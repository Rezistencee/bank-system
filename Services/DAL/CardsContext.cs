using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BankSystem.Models;

namespace BankSystem.Services.DAL;

public class CardsContext : DatabaseConnection
{
    private List<Card> _cards;

    public List<Card> Cards
    {
        get
        {
            return _cards;
        }
    }

    public CardsContext() : base()
    {
        _cards = null;
        GetCards();
    }
        
    public void GetCards()
    {
        List<Card> cards = new List<Card>();
            
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = "SELECT * FROM Cards";
                
            SqlCommand getCardsCommand = new SqlCommand(query, connection);

            using (SqlDataReader reader = getCardsCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    cards.Add(new Card
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        AccountID = Convert.ToInt32(reader["account_id"]),
                        Number = reader["card_number"].ToString(),
                        ExpirationDate = reader.GetDateTime(reader.GetOrdinal("expirationDate")),
                        StatusID = Convert.ToInt32(reader["status_id"])
                    });
                }
            }
        }

        _cards = cards;
    }
    
    public Card GetAccountCard(int accountID)
    {
        Card result = new Card();
            
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
                
            string query = 
                """
                SELECT * FROM Cards
                WHERE account_id = @accountID
                """;
                
            SqlCommand getAccountCardsCommand = new SqlCommand(query, connection);

            getAccountCardsCommand.Parameters.AddWithValue("@accountID", accountID);

            using (SqlDataReader reader = getAccountCardsCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new Card
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        AccountID = Convert.ToInt32(reader["account_id"]),
                        Number = reader["card_number"].ToString(),
                        ExpirationDate = reader.GetDateTime(reader.GetOrdinal("expirationDate")),
                        StatusID = Convert.ToInt32(reader["status_id"])
                    };
                }
            }
        }

        return result;
    }

    public int? GetAccountID(string cardNumber)
    {
        var card = Cards.FirstOrDefault(c => c.Number == cardNumber);
        return card?.AccountID;
    }
}