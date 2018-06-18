using System;

namespace ReminderPoc
{
    public class Time
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Seconds { get; private set; }

        public Time(int hour, int minute, int seconds = 0)
        {
            if (hour > 24)
            {
                throw new ArgumentException($"There are only 24 hours in a day, {hour} falls outside this range.");
            }

            if (minute > 60)
            {
                throw new ArgumentException($"There are only 60 minutes in an hour, {minute} falls outside this range.");
            }

            if (seconds > 60)
            {
                throw new ArgumentException($"There are only 60 seconds in a minute, {minute} falls outside this range.");
            }

            Hour = hour;
            Minute = minute;
            Seconds = seconds;
        }

        public override string ToString()
        {
            return $"{nString(Hour)}:{nString(Minute) }:{nString(Seconds)}";
        }

        private string nString(int n)
        {
            return n > 9 ? n.ToString() : "0" + n;
        }
    }
}