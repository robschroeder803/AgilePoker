namespace AgilePoker.Shared
{
    public class TextLogger : ILogger
    {
        public void Log(Enums.LogLevel level, string message, Exception? exception = null)
        {
            string logMessage = $"{DateTime.Now} [{level}] {message}{Environment.NewLine}";
            string todaysDate = DateTime.Now.ToString("yyyy-MM-dd");
            string logFileName = $"{todaysDate}.txt";
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs\\{logFileName}");
            File.AppendAllText(logFilePath, logMessage);
        }
    }
}
