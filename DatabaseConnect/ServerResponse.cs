using System;
using System.Runtime.CompilerServices;
using System.Threading;

public class ServerResponse
{
    private static readonly TimeSpan _sqlOpenDelay = TimeSpan.FromSeconds(3);
    private static readonly TimeSpan _sqlCloseDelay = TimeSpan.FromSeconds(3);
    private static readonly TimeSpan _oracleOpenDelay = TimeSpan.FromSeconds(3);
    private static readonly TimeSpan _oracleCloseDelay = TimeSpan.FromSeconds(3);
    /// <summary>
    /// Simulates the Delay of waiting for a response from a remote server
    /// <para> can be made to Delay for a variable amount of time depending on what type of connection is attempted.</para>
    /// <returns>ctor ServerResponse, void</returns>
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="callerName"></param>
    public ServerResponse(Object Sender, [CallerMemberName] string callerName = "")
    {
        var requester = Sender;
        if (callerName == "CloseConnection")
        {
            if (requester.GetType() == typeof(SqlConnection))
            {
                Thread.Sleep(_sqlCloseDelay);
                Console.Clear();
            }
            if (requester.GetType() == typeof(OracleConnection))
            {
                Thread.Sleep(_oracleCloseDelay);
                Console.Clear();
            }
        }
        else if (callerName == "OpenConnection")
        {
            if (requester.GetType() == typeof(SqlConnection))
            {
                Thread.Sleep(_sqlOpenDelay);
                Console.Clear();
            }
            if (requester.GetType() == typeof(OracleConnection))
            {
                Thread.Sleep(_oracleOpenDelay);
                Console.Clear();
            }
        }
        else
        {
            throw new NotImplementedException(string.Format("The Caller is not recognized. You must implement an option in the ServerResponse class for {0} to recieve a specific response", callerName));
        }
    }
}
