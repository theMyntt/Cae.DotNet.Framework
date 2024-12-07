namespace Cae.DotNet.Framework.Loggers
{
    public interface ILogger
    {
        /// <summary>
        /// Method for loggin normal info
        /// </summary>
        /// <param name="info">Info the thex to log</param>
        void LogInfo(string info);

        /// <summary>
        /// Method for loggin error info
        /// </summary>
        /// <param name="error">Error he text to log</param>
        void LogError(string error);

        /// <summary>
        /// Method for loggin debug info
        /// </summary>
        /// <param name="info">Info the texto to log</param>
        void LogDebug(string info);
    }
}
