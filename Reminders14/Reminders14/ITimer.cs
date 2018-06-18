using System;

namespace Reminders14
{
    public interface ITimer
    {
        event EventHandler<TimeEventArgs> OnTick;
    }

    public class Timer : ITimer
    {
        public event EventHandler<TimeEventArgs> OnTick;

        public Timer()
        {
            new System.Timers.Timer { Interval = 1000 }.Elapsed += (sender, args) =>
               {
                   OnTick?.Invoke(this, new TimeEventArgs(args.SignalTime));
               };
        }
    }
}