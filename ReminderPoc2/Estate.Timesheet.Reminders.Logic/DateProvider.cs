using System;
using Estate.Timesheet.Reminders.Logic.Interface;

namespace Estate.Timesheet.Reminders.Logic
{
    public class DateProvider : IDateProvider
    {
        public DateTime Now => DateTime.Now;
    }
}