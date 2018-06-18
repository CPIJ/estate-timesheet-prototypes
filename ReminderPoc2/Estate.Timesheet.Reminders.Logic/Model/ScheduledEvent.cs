using System;
using Estate.Timesheet.Reminders.Logic.Interface;

namespace Estate.Timesheet.Reminders.Logic.Model
{
    public class ScheduledEvent
    {
        private readonly IEvent @event;
        public Guid Id => @event.Id;
        public string Name => @event.Name;
        public Time ScheduledTime { get; }

        public Time TimeUntil
        {
            get
            {
                var now = DateTime.Now;
                var target = new DateTime(now.Year, now.Month, now.Day, ScheduledTime.Hours, ScheduledTime.Minutes, ScheduledTime.Seconds);

                var span =  now > target
                    ? target.AddDays(1) - now
                    : target - now;

                return new Time(span.Hours, span.Minutes, span.Seconds);
            }
        }

        public int TimesExecuted { get; set; }

        public ScheduledEvent(IEvent @event, Time scheduledTime)
        {
            this.@event = @event;
            ScheduledTime = scheduledTime;
            TimesExecuted = 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}