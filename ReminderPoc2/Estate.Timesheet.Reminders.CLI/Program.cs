using Estate.Timesheet.Reminders.Logic.Interface;
using Estate.Timesheet.Reminders.Logic.Util;

namespace Estate.Timesheet.Reminders.CLI
{
    class Program
    {
        private static readonly IEventScheduler EventScheduler;

        static void Main(string[] args)
        {
            EventScheduler.EventScheduled += (sender, e) =>
            {
                Logger.Log($"{e.Name} scheduled for {e.TimeUntil.ToString()}");
            };

            EventScheduler.EventFinished += (sender, e) =>
            {
                Logger.Log($"{e.Name} finished!");
            };

            while (true)
            {
                // Keeping to console alive.
            }
        }
    }
}
