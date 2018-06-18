namespace Reminders14
{
    public interface IReminder
    {
        string Platform { get; }
        string Target { get; }
        void Send();
    }
}
