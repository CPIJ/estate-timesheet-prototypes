using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Estate.Timesheet.Reminders.Logic.Interface;
using Estate.Timesheet.Reminders.Logic.Model;

namespace Estate.Timesheet.Reminders.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventScheduler eventScheduler;
        private ScheduledEvent currentEvent;
        private readonly DispatcherTimer timer = new DispatcherTimer();

        public MainWindow(IEventScheduler eventScheduler)
        {
            this.eventScheduler = eventScheduler;
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Start();
            timer.Tick += TimerOnTick;

            eventScheduler.EventScheduled += OnEventScheduled;
            eventScheduler.EventFinished += OnEventFinished;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (currentEvent == null) return;

            LbltimeUntil.Content = currentEvent.TimeUntil.ToString();
            LblTimesExecuted.Content = currentEvent.TimesExecuted.ToString();
        }

        private void OnEventFinished(object sender, ScheduledEvent @event)
        {
            LbxScheduledEvents.Items.Remove(@event);
        }

        private void OnEventScheduled(object sender, ScheduledEvent @event)
        {
            LbxScheduledEvents.Items.Add(@event);
        }

        private void LbxScheduledEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxScheduledEvents.SelectedItem is ScheduledEvent @event)
            {
                currentEvent = @event;
                LblScheduledTime.Content = currentEvent.ScheduledTime.ToString();
                LblTitle.Content = currentEvent.Name;
            }
        }
    }
}
