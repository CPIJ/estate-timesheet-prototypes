namespace Estate.Timesheet.Reminders.Service.Interface
{
    public interface IReminderService
    {
        void SendReminder(string email);
    }
}