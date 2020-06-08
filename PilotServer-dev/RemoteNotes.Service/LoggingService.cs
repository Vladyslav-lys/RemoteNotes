using log4net;

namespace RemoteNotes.Service
{
    public class LoggingService
    {
        private readonly ILog log;

        public LoggingService()
        {
            log = LogManager.GetLogger(typeof(LoggingService));
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Fatal(object message)
        {
            log.Fatal(message);
        }

        public void Warn(object message)
        {
            log.Warn(message);
        }
    }
}