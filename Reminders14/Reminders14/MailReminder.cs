using System;
using System.Net;
using System.Net.Mail;

namespace Reminders14
{
    public class MailReminder : IReminder
    {
        public string Platform { get; }
        public string Target { get; }

        public MailReminder(string email)
        {
            Target = email;
            Platform = "Mail";
        }

        public void Send()
        {
            Console.WriteLine($"Send mail to {Target}");
        }
    }
}
