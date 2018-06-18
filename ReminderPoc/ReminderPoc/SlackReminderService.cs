namespace ReminderPoc
{
    public class SlackReminderService : IReminderService
    {
        private ILogger logger;

        public SlackReminderService(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendReminder(User user)
        {
            logger.Info($"Send slack reminder to {user.Email}");
        }
    }
}