using System;
using System.Collections.Generic;
using System.Linq;

namespace ReminderPoc
{
    class EventBuilder
    {
        private Guid id;
        private readonly IList<Action> actions = new List<Action>();
        private int hours;
        private int minutes;
        private int seconds;

        public EventBuilder Id(Guid idd)
        {
            this.id = idd;
            return this;
        }

        public EventBuilder Hours(int hrs)
        {
            hours = hrs;
            return this;
        }

        public EventBuilder Minutes(int mins)
        {
            minutes = mins;
            return this;
        }

        public EventBuilder Seconds(int secs)
        {
            seconds = secs;
            return this;
        }

        public EventBuilder AddActions(params Action[] action)
        {
            foreach (var action1 in action)
            {
                actions.Add(action1);
            }

            return this;
        }

        public TimedEvent Build()
        {
            return new TimedEvent(id == Guid.Empty ? Guid.NewGuid() : id, new Time(hours, minutes, seconds), actions.ToArray());
        }
    }
}