namespace ReminderPoc
{
    internal class MailReminderService : IReminderService
    {
        private readonly ILogger logger;

        public MailReminderService(ILogger logger)
        {
            this.logger = logger;
        }


        public void SendReminder(User user)
        {
            logger.Info($"Sending mail to {user.Email}");
        }
    }
}