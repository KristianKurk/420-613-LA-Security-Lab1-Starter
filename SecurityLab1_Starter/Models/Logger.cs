using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SecurityLab1_Starter.Models
{
    public class Logger
    {
        public static void Log(string logMessage, System.IO.TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void Log(string logMessage, string path)
        {
            using (System.IO.StreamWriter w = System.IO.File.AppendText(path))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine("  :");
                w.WriteLine($"  :{logMessage}");
                w.WriteLine("-------------------------------");
            }
        }

        public static void DumpLog(System.IO.StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        public static void EventLog(string logMessage, EventLog el) {
            el.Source = "Application";
            el.WriteEntry(logMessage, EventLogEntryType.Error, 101, 1);
        }

        public static void EventLog(string logMessage, EventLog el, EventLogEntryType type)
        {
            el.Source = "Application";
            el.WriteEntry(logMessage, type, 101, 1);
        }

        public static void EventLog(string logMessage)
        {
            using (EventLog eventLog = new EventLog("Application"))
                Logger.EventLog(logMessage, eventLog);
        }
    }
}