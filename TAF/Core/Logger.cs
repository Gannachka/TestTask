using OpenQA.Selenium;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class Logger
    {
        public static ILogger Log { get; set; }

        public static void Debug(string messageTempplate)
        {
            Log.Write(LogEventLevel.Debug, messageTempplate);
        }
        public static void Debug(string messageTempplate, string text)
        {
            Log.Write(LogEventLevel.Debug, messageTempplate, text);
        }

        public static void Information(string messageTemplate)
        {
            Log.Write(LogEventLevel.Information, messageTemplate);
        }
        public static void Information(string messageTemplate, string text)
        {
            Log.Write(LogEventLevel.Information, messageTemplate);
        }
        public static void Information(string messageTempplate, By by)
        {
            Log.Write(LogEventLevel.Information, messageTempplate, by);
        }

        public static void Error(string messageTemplate)
        {
            Log.Write(LogEventLevel.Error, messageTemplate);
        }

        public static void Error(string messageTemplate, By by)
        {
            Log.Write(LogEventLevel.Error, messageTemplate, by);
        }

        public static void Fatal(string messageTemplate)
        {
            Log.Write(LogEventLevel.Fatal, messageTemplate);
        }
        public static void Fatal(string messageTemplate, object[] obj)
        {
            Log.Write(LogEventLevel.Fatal, messageTemplate, obj);
        }

        public static void Warning(string messageTemplate)
        {
            Log.Write(LogEventLevel.Warning, messageTemplate);
        }
        public static void Warning(string messageTemplate, object[] obj)
        {
            Log.Write(LogEventLevel.Warning, messageTemplate, obj);
        }
    }
}
