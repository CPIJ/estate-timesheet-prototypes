using System;
using System.Collections.Generic;

namespace ReminderPoc
{
    public interface IReminderFactory
    {
        Action[] Create(User user, IEnumerable<IReminderService> reminderServices);
    }
}