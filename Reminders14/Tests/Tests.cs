using System;
using System.Linq;
using System.Timers;
using Moq;
using NUnit.Framework;
using Reminders14;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private ReminderManager manager;
        private Mock<ITimer> timer;

        [SetUp]
        public void Setup()
        {
            timer = new Mock<ITimer>();
            manager = new ReminderManager(timer.Object);
        }

        [Test]
        public void Schedule_NoOtherEventsScheduledAtThisTime_CreatesNewEntryAndAddsTheReminders()
        {
            var r1 = CreateReminderMock("Test");

            manager.Schedule(12, 00, 00, r1.Object);

            Assert.That(manager.Status.Keys.Contains("12:00:00"));
            Assert.That(manager.Status["12:00:00"].Reminders["Test"].Count == 1);
        }

        [Test]
        public void Schedule_OtherEventsPlannedOnThisTime_AddsNewReminders()
        {
            var r1 = CreateReminderMock("Test");
            var r2 = CreateReminderMock("Test");

            manager.Schedule(12, 00, 00, r1.Object);
            manager.Schedule(12, 00, 00, r2.Object);

            Assert.That(manager.Status.Keys.Contains("12:00:00"));
            Assert.That(manager.Status["12:00:00"].Reminders["Test"].Count == 2);
        }

        [Test]
        public void Schedule_SameTimeWithDifferentPlatforms_SeparatesWhenFormatted()
        {
            var r1 = CreateReminderMock("First");
            var r2 = CreateReminderMock("Second");

            manager.Schedule(12, 00, 00, r1.Object);
            manager.Schedule(12, 00, 00, r2.Object);

            Assert.That(manager.Status["12:00:00"].Reminders["First"].Count == 1);
            Assert.That(manager.Status["12:00:00"].Reminders["Second"].Count == 1);
        }

        [Test]
        public void Schedule_TimeIsCorrect_GetsTriggered()
        {
            var r1 = CreateReminderMock("Test");
            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            manager.Schedule(time.Hour, time.Minute, time.Second, r1.Object);
            timer.Raise(t => t.OnTick += null, new TimeEventArgs(time));

            r1.Verify(r => r.Send(), Times.Once);
        }

        [Test]
        public void Schedule_TimeIsNotCorrect_DoesNotGetTriggered()
        {
            var r1 = CreateReminderMock("Test");
            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            manager.Schedule(time.AddHours(1).Hour, time.Minute, time.Second, r1.Object);
            timer.Raise(t => t.OnTick += null, new TimeEventArgs(time));

            r1.Verify(r => r.Send(), Times.Never);
        }

        [Test]
        public void Schedule_MultipleTriggered()
        {
            const int h = 12, m = 0, s = 0;
            var reminders = Enumerable.Range(0, 10).Select(n => CreateReminderMock("Test")).ToArray();
            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, s);

            foreach (var reminder in reminders)
            {
                manager.Schedule(h, m, s, reminder.Object);
            }

            timer.Raise(t => t.OnTick += null, new TimeEventArgs(time));

            foreach (var reminder in reminders)
            {
                reminder.Verify(r => r.Send(), Times.Once);
            }
        }

        private static Mock<IReminder> CreateReminderMock(string platform)
        {
            var mock = new Mock<IReminder>();
            mock.Setup(m => m.Platform).Returns(platform);

            return mock;
        }
    }
}