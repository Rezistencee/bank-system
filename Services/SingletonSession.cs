using System;
using BankSystem.Models;

public interface ISession
{
    Client Client { get; }
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

            public Session(Client authorizedClient)
            {
                Client = authorizedClient;
            }
        }
        
        public ISession CurrentSession
        {
            get => _session;
        }
        
        private SingletonSession(Client client)
        {
            _session = new Session(client);
        }
        
        public static SingletonSession GetInstance()
        {
            if (_instance == null)
                throw new InvalidOperationException("SingletonSession has not been initialized.");
            
            return _instance;
        }

        public static void Initialize(Client client)
        {
            if (_instance != null)
                throw new InvalidOperationException("SingletonSession has already been initialized.");

            _instance = new SingletonSession(client);
        }
    }
}