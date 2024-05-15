using log4net;

namespace OnBoardingCountriesBE.Logger
{
    public class Log4net
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private Log4net()
        {

        }
        public void Log(string message)
        {
            log.Info(message);
        }

        public static ILog _log => log;
    }
}
