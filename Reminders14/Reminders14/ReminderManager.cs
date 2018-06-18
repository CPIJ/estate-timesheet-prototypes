using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;


namespace Reminders14
{
    public class ReminderManager : IReminderManager
    {
        private readonly IDictionary<string, IList<IReminder>> events;
        public Dictionary<string, ScheduledEvents> Status => events
            .ToDictionary(p => p.Key, p => new ScheduledEvents(DateTime.Parse(p.Key), p.Value))
            .OrderBy(pair => pair.Value.DueIn)
            .ToDictionary(p => p.Key, p => p.Value);

        public ReminderManager(ITimer timer)
        {
            events = new Dictionary<string, IList<IReminder>>();
            timer.OnTick += OnTick;
        }

        private void OnTick(object sender, TimeEventArgs args)
        {
            string time = args.RaisedAt.ToString("T");

            if (!events.ContainsKey(time))
            {
                return;
            }

            Parallel.ForEach(events[time], reminder => reminder.Send());
        }

        public void Schedule(int hour, int minute, int second, params IReminder[] reminders)
        {
            string time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second)
                .ToString("T");

            if (!events.ContainsKey(time))
            {
                events[time] = new List<IReminder>();
            }

            foreach (var reminder in reminders)
            {
                events[time].Add(reminder);
            }
        }
    }
}
