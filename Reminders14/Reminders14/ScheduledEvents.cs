using System;
using System.Collections.Generic;

namespace Reminders14
{
    public class ScheduledEvents
    {
        public string DueIn { get; private set; }
        public IDictionary<string, IList<string>> Reminders { get; private set; }

        public ScheduledEvents(DateTime time, IEnumerable<IReminder> reminders)
        {
            Reminders = new Dictionary<string, IList<string>>();
            DueIn = ((DateTime.Now > time ? time.AddDays(1) : time) - DateTime.Now).ToString("T");

            foreach (var r in reminders)
            {
                if (!Reminders.ContainsKey(r.Platform))
                {
                    Reminders.Add(r.Platform, new List<string>());
                }

                Reminders[r.Platform].Add(r.Target);
            }
        }
    }
}