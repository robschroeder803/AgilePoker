using static AgilePoker.Shared.Enums;

namespace AgilePoker.Shared
{
    public interface ILogger
    {
        /// <summary>
        /// Logs a message at the Information level
        /// </summary>
        /// <param name="message"></param>
        void Log(LogLevel level, string message, Exception exception = null);
    }
}
