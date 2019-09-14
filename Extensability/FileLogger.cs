using System.IO;

namespace Extensability
{
    public class FileLogger : ILogger
    {
        private readonly string path;
        public FileLogger(string path)
        {
            this.path = path;
        }

        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }
        private void Log(string message, string messageType)
        {
            using (var streamWriter = new StreamWriter(this.path, true))
            {
                streamWriter.WriteLine(messageType + ": " + message);
            }
        }
    }
}
