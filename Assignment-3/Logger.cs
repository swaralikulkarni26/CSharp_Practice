using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment_3
{
    public class Logger
    {
        public static void WriteLog(string Message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))

                {
                    writer.WriteLine($"{DateTime.Now} : {Message}");
                }
            }catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}