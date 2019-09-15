using System;
/// <summary>
/// Starts an SQL Connection. Based on DBConnection
/// </summary>
public class SqlConnection : DbConnection
{
    private const int _defaultTimeout = 5;
    public SqlConnection(string connectionString, int timeout = _defaultTimeout) : base(connectionString)
    {
        this.Timeout = TimeSpan.FromSeconds(timeout);
        // Set the value of timeout in this object (will default to 5 if not passed as parameter)
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
