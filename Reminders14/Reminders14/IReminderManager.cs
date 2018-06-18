using System.Collections.Generic;

namespace Reminders14
{
    public interface IReminderManager
    {
        Dictionary<string, ScheduledEvents> Status { get; }

        void Schedule(int hour, int minute, int second, params IReminder[] reminders);
    }
}