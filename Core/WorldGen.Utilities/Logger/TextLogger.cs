using System;
using System.IO;

namespace WorldGen.Utilities.Logger
{
    public class TextLogger : ILogger
    {
        public void WriteLog(string toWrite)
        {
            //ToDo
            string file;
            TextWriter tw;
            file = @"Logs\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if(!File.Exists(file))
            {
                System.IO.Directory.CreateDirectory(@"Logs");
                tw = new StreamWriter(File.Create(file));
            }
            else
            {
                tw = new StreamWriter(file, true);
            }
            tw.WriteLine(toWrite);
            tw.Close();
        }
    }
}