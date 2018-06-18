using Estate.Timesheet.Reminders.Logic.Util;
using Estate.Timesheet.Reminders.Service.Interface;

namespace Estate.Timesheet.Reminders.Service
{
    public class MailReminderService : IReminderService
    {
        public void SendReminder(string email)
        {
            Logger.Log($"Send mail to {email}");
        }
    }
}