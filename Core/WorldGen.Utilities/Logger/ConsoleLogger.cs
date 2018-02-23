using System;

namespace WorldGen.Utilities.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLog(string toWrite)
        {
            Console.WriteLine(toWrite);
        }
    }
}