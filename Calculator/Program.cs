using System;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Calculator
{
    public class AwesomeStopwatch : IDisposable
    {
        private DateTime _stopwatchTime;

        public AwesomeStopwatch()
        {
            this._stopwatchTime = DateTime.MinValue;

        }

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public void Start()
        {
            try
            {
                if (_stopwatchTime == DateTime.MinValue)
                {
                    this._stopwatchTime = DateTime.Now;

                    Console.Clear();
                    Console.WriteLine("Stopwatch Started at {0}", _stopwatchTime);
                    Console.WriteLine("(Press return to continue)");
                    Console.ReadLine();
                }
                else
                {
                    throw new InvalidOperationException();
                }

            }
            catch (InvalidOperationException)
            {
                Console.Clear();
                Console.WriteLine("The stopwatch is already running...");
                Console.WriteLine("(Press return to continue)");
                Console.ReadLine();
            }

        }
        public void Stop()
        {
            try
            {
                if (_stopwatchTime == DateTime.MinValue)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    Console.Clear();
                    var stopTime = DateTime.Now;
                    TimeSpan interval = stopTime - _stopwatchTime;
                    Console.WriteLine("Stopwatch Stopped at {0}", stopTime);
                    Console.WriteLine("Total Time Elapsed: {0}", interval);
                    Console.WriteLine("(Press return to continue)");
                    Console.ReadLine();
                }

            }
            catch (InvalidOperationException)
            {
                Console.Clear();
                Console.WriteLine("No Running stopwatch...");
                Console.WriteLine("(Press return to continue)");
                Console.ReadLine();
            }
            finally
            {
                if (_stopwatchTime != DateTime.MinValue)
                {
                    Dispose();
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            AwesomeStopwatch stopwatch = new AwesomeStopwatch();
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Awesome Stopwatch!");
                Console.WriteLine("================================");
                Instructions();
                input = Console.ReadKey(true);
                Initialize(input, stopwatch);
            } while (input.Key != ConsoleKey.Escape);
        }
        static void Initialize(ConsoleKeyInfo input, AwesomeStopwatch stopwatch)
        {
            
                if (input.KeyChar == (char)Keys.D0)
                {
                    stopwatch.Start();
                }
                if (input.KeyChar == (char)Keys.D1)
                {
                    stopwatch.Stop();
                }

            
        }
        static void Instructions()
        {
            Console.WriteLine("Instructions:\n");
            Console.WriteLine("Press the '0' key to start the stopwatch.\nPress the '1' key to stop the Stopwatch \nPress the (esc) key to quit.");
        }
    }
}
