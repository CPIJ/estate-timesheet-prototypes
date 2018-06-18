using System.Threading.Tasks;

namespace Estate.Timesheet.Reminders.Logic.Interface
{
    public class Waiter : IWaiter
    {
        public async Task Wait(double milliseconds)
        {
            await Task.Delay((int)milliseconds);
        }
    }
}