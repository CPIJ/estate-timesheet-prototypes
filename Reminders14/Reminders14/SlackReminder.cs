using System;

namespace Reminders14
{
    internal class SlackReminder : IReminder
    {
        public SlackReminder(string username)
        {
            Target = username;
            Platform = "Slack";
        }

        public void Send()
        {
            Console.WriteLine($"Send via slack to {Target}");
        }

        public string Platform { get; }
        public string Target { get; }
    }
}