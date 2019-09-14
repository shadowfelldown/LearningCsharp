using System;
using System.Windows.Forms;


namespace StopWatch
{
    internal enum State { start, isrunning, noStopwatch, swStarted, swStopped, instructions }
    
    /// <summary>
    /// Awesome Stopwatch Times things. has Start and stop methods.
    /// </summary>
    public class AwesomeStopwatch
    {
        private static DateTime _stopwatchTime;

        static AwesomeStopwatch()
        {
            _stopwatchTime = DateTime.MinValue;

        }

        /// <summary>
        /// Starts the stopwatch class. Throws error if stopwatch allready running.
        /// </summary>
        public static void Start()
        {
            try
            {
                if (_stopwatchTime == DateTime.MinValue)
                {
                    _stopwatchTime = DateTime.Now;

                    Program.WriteText(State.swStarted, _stopwatchTime);
                    Program.ContinuePrompt();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                Program.WriteText(State.isrunning);
                Program.ContinuePrompt();
            }
        }

        /// <summary>
        /// Stops the stopwatch class. Throws error if stopwatch not started.
        /// </summary>
        public static void Stop()
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
                    DateTime stopTime = DateTime.Now;
                    Program.WriteText(State.swStopped, stopTime, (stopTime - _stopwatchTime));
                    Program.ContinuePrompt();
                }

            }
            catch (InvalidOperationException)
            {
                Program.WriteText(State.noStopwatch);
                Program.ContinuePrompt();
            }
            finally
            {
                _stopwatchTime = DateTime.MinValue;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteText(State.start);
            ConsoleKeyInfo input;
            do
            {
                WriteText(State.instructions);
                input = Console.ReadKey(true);
                readInput(input);
            } while (input.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// reads input from the user
        /// </summary>
        /// <param name="input"></param>
        static void readInput(ConsoleKeyInfo input)
        {
            if (input.KeyChar == (char)Keys.D0)
            {
                AwesomeStopwatch.Start();
            }
            if (input.KeyChar == (char)Keys.D1)
            {
                AwesomeStopwatch.Stop();
            }
        }

        /// <summary>
        /// Writes Text to the Console based on required currentState enum. Can accept an optional DateTime and TimeSpan as well to display details.
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="stopTime"></param>
        /// <param name="interval"></param>
        public static void WriteText(State currentState, DateTime stopTime = default, TimeSpan interval = default)
        {
            Console.Clear();
            switch (currentState)
            {
                case State.start:
                    Console.WriteLine("Welcome to the Awesome Stopwatch!");
                    Console.WriteLine("================================");
                    break;
                case State.isrunning:
                    Console.WriteLine("The Stopwatch is already running...");
                    break;
                case State.noStopwatch:
                    Console.WriteLine("No Running stopwatch...");
                    break;
                case State.instructions:
                    Console.WriteLine("Instructions:\n");
                    Console.WriteLine("================================");
                    Console.WriteLine("Press the '0' key to start the stopwatch.\nPress the '1' key to stop the Stopwatch \nPress the (esc) key to quit.");
                    break;
                case State.swStarted:
                    Console.WriteLine("Stopwatch Started at {0}", stopTime);
                    break;
                case State.swStopped:
                    Console.WriteLine("Stopwatch Stopped at {0}", stopTime);
                    Console.WriteLine("Total Time Elapsed: {0}", interval);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays a prompt to continue and waits for user input.
        /// </summary>
        public static void ContinuePrompt()
        {
            Console.WriteLine("(Press any key to continue)");
            Console.ReadKey();
        }
    }
}