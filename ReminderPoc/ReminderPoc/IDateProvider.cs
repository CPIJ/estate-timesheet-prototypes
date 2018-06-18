using System;

namespace ReminderPoc
{
    public interface IDateProvider
    {
        bool IsWeekend();
        DateTime Now();
    }

    public class DateProvider : IDateProvider
    {
        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}