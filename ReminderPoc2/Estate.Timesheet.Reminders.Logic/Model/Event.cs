using System;
using System.Collections.Generic;
using Estate.Timesheet.Reminders.Logic.Interface;

namespace Estate.Timesheet.Reminders.Logic.Model
{
    public class Event : IEvent
    {
        private readonly IList<Action> actions;
        public Guid Id { get; }
        public string Name { get; }

        public Event(string name, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            actions = new List<Action>();
        }

        public Event WithAction(Action action)
        {
            actions.Add(action);
            return this;
        }

        public void Execute()
        {
            foreach (var action in actions)
            {
                action();
            }
        }
    }
}