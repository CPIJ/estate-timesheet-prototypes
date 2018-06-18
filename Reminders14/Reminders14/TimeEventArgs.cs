using System;

namespace Reminders14
{
    public class TimeEventArgs : EventArgs
    {
        public TimeEventArgs(DateTime raisedAt)
        {
            RaisedAt = raisedAt;
        }

        public DateTime RaisedAt { get; }
    }
}