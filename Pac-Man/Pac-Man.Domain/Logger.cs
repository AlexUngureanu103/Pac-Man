namespace Pac_Man.Domain
{
    public interface IDataLogger
    {
        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="message">Info message to display into the logger file</param>
        void LogInfo(string message);

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">Debug message to display into the logger file</param>
        void LogDebug(string message);

        /// <summary>
        /// Log warn message
        /// </summary>
        /// <param name="message">Warning message to display into the logger file</param>
        void LogWarn(string message);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">Error message to display into the logger file</param>
        void LogError(string message);


        /// <summary>
        /// Log error message with exception
        /// </summary>
        /// <param name="message">Error message to display into the logger file</param>
        /// <param name="ex">Exception stack traces and inner exceptions to display intro the logger file</param>
        void LogError(string message, Exception ex);
    }

    public class Logger : IDataLogger
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void SetLogger(log4net.ILog logger)
        {
            log = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void LogDebug(string debugMessage)
        {
            log.Debug(debugMessage);
        }

        public void LogError(string errorMessage)
        {
            log.Error(errorMessage);
        }

        public void LogError(string message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void LogInfo(string infoMessage)
        {
            log.Info(infoMessage);
        }

        public void LogWarn(string warnMessage)
        {
            log.Warn(warnMessage);
        }
    }
}
