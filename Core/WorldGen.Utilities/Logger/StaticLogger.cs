using WorldGen.Utilities.Enum;

namespace WorldGen.Utilities.Logger
{
    public static class StaticLogger
    {
        
        private static ILogger logger = new DummyLogger();

        public static void SetLoggerType(LoggerTypes loggerType)
        {
            switch(loggerType)
            {
                case LoggerTypes.DUMMY:
                default:
                logger = new DummyLogger();
                break;
                case LoggerTypes.CONSOLE:
                logger = new ConsoleLogger();
                break;
                case LoggerTypes.TEXT:
                logger = new TextLogger();
                break;
            }
        }

        public static void WriteLog(string toWrite)
        {
            logger.WriteLog(toWrite);
        }
    }
}