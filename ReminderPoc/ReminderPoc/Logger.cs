using System;
using System.IO;

namespace ReminderPoc
{
    class Logger : ILogger
    {
        public void Info(string text)
        {
            Log(text, "INFO");
        }

        private void Log(string text, string prefix)
        {
            string message = $"{DateTime.Now:T} - {prefix}: {text}";

            Console.WriteLine(message);
        }
    }
}