using DatabaseConnect;
using System;
/// <summary>
/// Create A database connection
/// </summary>
public abstract class DbConnection
{
    public string ConnectionString { get; set; }
    public TimeSpan Timeout { get; set; }
    private const int _defaultTimeout = 5;
    public DbConnection(string connectionString, int timeout = _defaultTimeout)
    {
        try
        {
            this.ConnectionString = connectionString;
            //will throw ArgumentNullException if this is null.
            if (timeout <= 0)
            {
                throw new ArgumentOutOfRangeException("Timeout must be a positive non-zero number.");
                //Make sure that an invalid Timeout parameter is not passed.
            }
        }
        catch (ArgumentNullException)
        {

            Console.WriteLine("Invalid database connection string entered. No connection established.");
        }


    }
    public abstract void OpenConnection();
    public abstract void CloseConnection();
    public void LogConnectionStatus(Object Sender, bool isSucessful, Operation operation)
    {
        string connType = "";
        string opType = "";
        var reqType = Sender.GetType();
        try
        {
            switch (reqType.ToString())
            {
                case "SqlConnection":
                    connType = "SQL";
                    break;
                case "OracleConnection":
                    connType = "Oracle";
                    break;
                default:
                    throw new ArgumentException();
            }
            switch (operation)
            {
                case Operation.Open:
                    opType = "Opened";
                    break;
                case Operation.Close:
                    opType = "Closed";
                    break;
                default:
                    throw new ArgumentException();
            }
            if (isSucessful)
            {
                Console.WriteLine("{0} Connection has been {1} sucessfully.", connType, opType);
            }
            else
            {
                Console.WriteLine("Operation Failed: {0} Connection has not been {1}", connType, opType);
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Operation Failed: Connection type or operation type must match a valid option");
            throw;
        }

    }

}
