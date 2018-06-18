using System;

namespace Estate.Timesheet.Reminders.Logic.Interface
{
    public interface IEvent
    {
        Guid Id { get; }
        string Name { get;  }
        void Execute();
    }
}