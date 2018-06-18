using System;
using Estate.Timesheet.Reminders.Logic.Model;

namespace Estate.Timesheet.Reminders.Logic.Interface
{
    public interface IEventScheduler
    {
        void Schedule(IEvent e, Time time, Func<int, bool> maySchedule);
        event EventsScheduledHandler EventScheduled;
        event EventFinishedHandler EventFinished;
    }
}