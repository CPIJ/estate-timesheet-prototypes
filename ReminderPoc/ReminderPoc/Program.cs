using System;

namespace ReminderPoc
{
    class Program
    {
        private static readonly User User = new User { Email = "c.pijnenburg@estate.nl" };
        private static readonly ILogger Logger = new Logger();

        static void Main(string[] args)
        {
            var slackService = new SlackReminderService(Logger);
            var mailService = new MailReminderService(Logger);

            var @event = new EventBuilder()
                .Hours(10)
                .Minutes(52)
                .AddActions
                (
                    () => slackService.SendReminder(User),
                    () => mailService.SendReminder(User)
                )
                .Build();

            @event.Schedule(ScheduleType.RepeatOnWeekDays);
        }
    }
}
