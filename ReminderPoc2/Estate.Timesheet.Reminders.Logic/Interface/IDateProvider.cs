using System;

namespace Estate.Timesheet.Reminders.Logic.Interface
{
    public interface IDateProvider
    {
        DateTime Now { get; }
    }
}