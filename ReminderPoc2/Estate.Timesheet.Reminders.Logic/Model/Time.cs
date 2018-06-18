using System;

namespace Estate.Timesheet.Reminders.Logic.Model
{
    public class Time
    {
        public int Hours { get; }
        public int Minutes { get; }
        public int Seconds { get; }

        public Time(int hours, int minutes, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string ToString()
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, Hours, Minutes, Seconds).ToString("T");
        }

        public double TotalMilliseconds()
        {
            return new TimeSpan(0, Hours, Minutes, Seconds).TotalMilliseconds;
        }
    }
}