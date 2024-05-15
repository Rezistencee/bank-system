using System;

namespace BankSystem.Models;

public class ClientTypes
{
    private ClientTypes(string value)
    {
        Value = value; 
    }

    public string Value { get; private set; }

    public static ClientTypes Physical
    {
        get { return new ClientTypes("Фізична особа"); }
    }

    public static ClientTypes Legal
    {
        get { return new ClientTypes("Юридична особа"); }
    }
    
    public static ClientTypes FromNumericValue(short numericValue)
    {
        switch (numericValue)
        {
            case 1:
                return Physical;
            case 2:
                return Legal;
            default:
                throw new ArgumentException("Invalid numeric value for ClientType.");
        }
    }

    public override string ToString()
    {
        return Value;
    }
}