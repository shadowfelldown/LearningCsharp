using System;

namespace DatabaseConnect
{
    public enum Operation
    {
        Open,
        Close
    }
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "This is a connection String";
            var connection = new OracleConnection(connectionString, 5);
            try
            {
                TimeoutTester(connection, Operation.Open);
                Console.WriteLine("Press Any key to close the connection...");
                Console.ReadKey();
                TimeoutTester(connection, Operation.Close);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Argument exception occurred, the application will now terminate");
            }
            catch (TimeoutException)
            {

                Console.WriteLine("The request to the server has timed out.");
            }
            Console.WriteLine("Press Any key to close...");
            Console.ReadKey();
        }

        private static void TimeoutTester(OracleConnection connection, Operation op)
        {
            var startTime = DateTime.Now;
            try
            {
                while (true)
                {
                    switch (op)
                    {
                        case Operation.Open:
                            connection.OpenConnection();
                            break;
                        case Operation.Close:
                            connection.CloseConnection();
                            break;
                        default:
                            break;
                    }
                    if (DateTime.Now.Subtract(startTime).TotalSeconds > connection.Timeout.TotalSeconds)
                    {
                        connection.LogConnectionStatus(connection, false, op);
                        throw new TimeoutException();
                    }
                    else
                    {
                        connection.LogConnectionStatus(connection, true, op);
                        break;
                    }
                }
            }
            catch (ArgumentException)
            {
                throw;
            }

        }
    }
}
