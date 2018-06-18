using System;

namespace ReminderPoc
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Team Team { get; set; }
        public string Function { get; set; }
    }
}