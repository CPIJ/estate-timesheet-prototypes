using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReminderPoc
{
    public class TimedEvent
    {
        private  readonly ILogger logger = new Logger();
        private readonly IDateProvider dateProvider = new DateProvider();
        private Thread thread;
        public Guid Id { get; }
        public IEnumerable<Action> Actions { get; private set; }
        public Time ScheduledTime { get; private set; }
        public int TimesExecuted { get; private set; }
        public Time TimeUntil
        {
            get
            {
                var difference = CalculateDifference();
                return new Time(difference.Hours, difference.Minutes, difference.Seconds);
            }
        }

        public TimedEvent(Guid id, Time scheduledTime, params Action[] actions)
        {
            Id = id;
            Actions = actions;
            ScheduledTime = scheduledTime;
        }

        public void Schedule(ScheduleType type)
        {
            if (type == ScheduleType.Once && TimesExecuted > 0)
            {
                return;
            }

            logger.Info($"{Id} due in {TimeUntil}");

            var difference = CalculateDifference();

            thread = new Thread(() =>
            {
                Thread.Sleep((int)difference.TotalMilliseconds);

                if (type == ScheduleType.RepeatOnWeekDays && !dateProvider.IsWeekend())
                {
                    foreach (var action in Actions)
                    {
                        action();
                    }

                    TimesExecuted++;
                }

                Schedule(type);
            });

            thread.Start();
        }

        private TimeSpan CalculateDifference()
        {
            var now = dateProvider.Now();
            var target = new DateTime(now.Year, now.Month, now.Day, ScheduledTime.Hour, ScheduledTime.Minute, ScheduledTime.Seconds);

            return now > target
                ? target.AddDays(1) - now  // Schedule for tomorrow
                : target - now;            // Schdule for today
        }
    }
}