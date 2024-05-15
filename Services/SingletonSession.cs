using System;
using System.Collections.Generic;
using BankSystem.Models;

public interface ISession
{
    Client Client { get; }
    List<Account> Accounts { get; }
    List<Card> Cards { get; }
}

namespace BankSystem.Services
{
    public class SingletonSession
    {
        private static SingletonSession _instance;
        private Session _session;
        
        internal struct Session : ISession
        {
            public Client Client { get; }
            public List<Account> Accounts { get; }
            public List<Card> Cards { get; }

            public Session(Client authorizedClient)
            {
                Client = authorizedClient;
                Accounts = new List<Account>(1);
                Cards = new List<Card>(1);
            }
        }

        public static SingletonSession Instance
        {
            get => _instance;
        }
        
        public ISession CurrentSession
        {
            get => _session;
        }
        
        private SingletonSession(Client client)
        {
            _session = new Session(client);
        }

        public static void Initialize(Client client)
        {
            if (_instance != null)
                throw new InvalidOperationException("SingletonSession has already been initialized.");

            _instance = new SingletonSession(client);
        }
    }
}