using System;

namespace Estate.Timesheet.Reminders.Logic.Util
{
    public static class Repeat
    {
        public static bool Once(int timesRepeated) => timesRepeated <= 0;
        public static Func<int, bool> Times(int n) => timesRepeated => timesRepeated < n;
        public static bool EveryDay(int n) => true;        
    }
}