using System;

namespace Estate.Timesheet.Reminders.Logic.Util
{
    public static class Logger
    {
        public static void Log(string text)
        {
            string message = $"{DateTime.Now:T}: {text}";
            Console.WriteLine(message);
        }
    }
}