using Estate.Timesheet.Reminders.Logic.Util;
using Estate.Timesheet.Reminders.Service.Interface;

namespace Estate.Timesheet.Reminders.Service
{
    public class SlackReminderService : IReminderService
    {
        public void SendReminder(string email)
        {
            Logger.Log($"Send slack message to {email}.");
        }
    }
}