using System;
/// <summary>
/// Starts an Oracle Connection. Based on DBConnection
/// </summary>
public class OracleConnection : DbConnection
{
    private const int _defaultTimeout = 5;
    public OracleConnection(string connectionString, int timeout = _defaultTimeout) : base(connectionString, timeout)
    {
        this.Timeout = TimeSpan.FromSeconds(_defaultTimeout);
    }

    public override void CloseConnection()
    {
        Console.WriteLine("Closing Connection...");
        new ServerResponse(this);
        // Wait simulates server response.
    }

    public override void OpenConnection()
    {
        Console.WriteLine("Opening Connection...");
        new ServerResponse(this);
        // Wait simulates server response.
    }
}
