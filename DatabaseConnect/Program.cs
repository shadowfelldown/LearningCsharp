using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace DatabaseConnect
{
    public class ServerResponse
    {
        private static readonly TimeSpan _sqlOpenDelay = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan _sqlCloseDelay = TimeSpan.FromSeconds(5);
        private static readonly TimeSpan _oracleOpenDelay = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan _oracleCloseDelay = TimeSpan.FromSeconds(5);
        public ServerResponse(Object Sender, [CallerMemberName] string callerName = "")
        {
            var requester = Sender;
            Console.WriteLine(callerName);
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
            if (callerName == "OpenConnection")
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
    public class SqlConnection : DbConnection
    {
        private const int _defaultTimeout = 5;
        public SqlConnection(string connectionString, int timeout=_defaultTimeout) : base(connectionString)
        {
                this.Timeout = TimeSpan.FromSeconds(timeout);
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing Connection...");
            new ServerResponse(this);
            Console.WriteLine("Sql Connection is now closed");
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening Connection...");
            new ServerResponse(this);
            Console.Clear();
            Console.WriteLine("SqlConnection is now opened.");
        }
    }
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
            Console.WriteLine("Oracle Connection is now closed");
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening Connection...");
            new ServerResponse(this);
            Console.Clear();
            Console.WriteLine("Oracle Connection is now opened.");
        }
    }
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
                if (timeout <= 0)
                {
                    throw new ArgumentOutOfRangeException("Timeout must be a positive non-zero number.");
                }
            }
            catch (ArgumentNullException)
            {

                Console.WriteLine("Invalid database connection string entered. No connection established.");
            }


        }
        public abstract void OpenConnection();
        public abstract void CloseConnection();

    }
    class Program
    {
        public delegate void timeoutTimer();
        static void Main(string[] args)
        {
            string connectionString = "This is a connection String";
            //string connectionString = null;
            var connection = new OracleConnection(connectionString, 2);
            //var connection = new SqlConnection(connectionString,3);
            try
            {
                var startTime = DateTime.Now;
                while (true)
                {
                    connection.OpenConnection();
                    if (DateTime.Now.Subtract(startTime).TotalSeconds > connection.Timeout.TotalSeconds)
                    {
                        throw new TimeoutException();
                    }
                    else
                    {
                        break;
                    }
                }
                Thread.Sleep(2000);
                startTime = DateTime.Now;
                while (true)
                {
                    connection.CloseConnection();
                    if (DateTime.Now.Subtract(startTime).TotalSeconds > connection.Timeout.TotalSeconds)
                    {
                        throw new TimeoutException();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch  (ArgumentException)
            {

            }
            catch (TimeoutException)
            {

                Console.WriteLine("The request to the server has timed out.");
            }
            Console.WriteLine("Press Any key to close...");
            Console.ReadKey();
        }
    }
}
