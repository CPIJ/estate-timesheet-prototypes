using System;
using System.Threading.Tasks;
using Estate.Timesheet.Reminders.Logic.Interface;
using Estate.Timesheet.Reminders.Logic.Model;

namespace Estate.Timesheet.Reminders.Logic
{
    public class EventScheduler : IEventScheduler
    {
        private readonly IDateProvider dateProvider;
        private readonly IWaiter waiter;

        public event EventsScheduledHandler EventScheduled;
        public event EventFinishedHandler EventFinished;

        public EventScheduler(IDateProvider dateProvider, IWaiter waiter)
        {
            this.dateProvider = dateProvider;
            this.waiter = waiter;
        }

        public void Schedule(IEvent @event, Time time, Func<int, bool> maySchedule)
        {
            var scheduled = new ScheduledEvent(@event, time);

            Task.Run(async () =>
            {
                EventScheduled?.Invoke(this, scheduled);

                while (maySchedule(scheduled.TimesExecuted))
                {
                    await waiter.Wait(scheduled.TimeUntil.TotalMilliseconds());

                    @event.Execute();
                    scheduled.TimesExecuted++;
                }

                EventFinished?.Invoke(this, scheduled);
            });
        }


    }

    public delegate void EventFinishedHandler(object sender, ScheduledEvent @event);

    public delegate void EventsScheduledHandler(object sender, ScheduledEvent @event);
}