using System.Threading.Tasks;

namespace Estate.Timesheet.Reminders.Logic.Interface
{
    public interface IWaiter
    {
        Task Wait(double milliseconds);
    }
}