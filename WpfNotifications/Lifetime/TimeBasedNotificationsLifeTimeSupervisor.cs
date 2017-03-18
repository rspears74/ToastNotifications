using System;
using System.Linq;
using System.Windows.Threading;
using WpfNotifications.Core;
using WpfNotifications.Utilities;

namespace WpfNotifications.Lifetime
{
    internal class TimeBasedNotificationsLifeTimeSupervisor : INotificationsLifeTimeSupervisor
    {
        private readonly TimeSpan _notificationLifeTime;
        private readonly int _maximumNotificationCount;
        private readonly Dispatcher _dispatcher;
        private NotificationsList _notifications;
        private readonly IInterval _interval;
        private DispatcherTimer _timer;

        public TimeBasedNotificationsLifeTimeSupervisor(TimeSpan notificationLifeTime, int maximumNotificationCount, Dispatcher dispatcher)
        {
            _maximumNotificationCount = maximumNotificationCount;
            _notifications = new NotificationsList();

            _notificationLifeTime = notificationLifeTime;
            _maximumNotificationCount = maximumNotificationCount;
            _dispatcher = dispatcher;

            _notifications =  new NotificationsList();
            _interval = new Interval();
            _timer = new DispatcherTimer(DispatcherPriority.Normal, dispatcher);
            _timer.Interval = TimeSpan.FromMilliseconds(200);
            _timer.Tick += OnTimerTick;
        }

        public void PushNotification(INotification notification)
        {
            if (_timer.IsEnabled == false)
                _timer.Start();

            int numberOfNotificationsToClose = Math.Max(_notifications.Count - _maximumNotificationCount, 0);

            var notificationsToRemove = _notifications
                .OrderBy(x => x.Key)
                .Take(numberOfNotificationsToClose)
                .Select(x => x.Value)
                .ToList();

            foreach (var n in notificationsToRemove)
                CloseNotification(n.Notification);

            _notifications.Add(notification);
            RequestShowNotification(new ShowNotificationEventArgs(notification));
        }

        public void CloseNotification(INotification notification)
        {
            NotificationMetaData removedNotification;
            _notifications.TryRemove(notification.Id, out removedNotification);
            RequestCloseNotification(new CloseNotificationEventArgs(removedNotification.Notification));
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer = null;
            _notifications?.Clear();
            _notifications = null;
        }

        protected virtual void RequestShowNotification(ShowNotificationEventArgs e)
        {
            ShowNotificationRequested?.Invoke(this, e);
        }

        protected virtual void RequestCloseNotification(CloseNotificationEventArgs e)
        {
            CloseNotificationRequested?.Invoke(this, e);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            TimeSpan now = DateTimeNow.Local.TimeOfDay;

            var notificationsToRemove = _notifications
                .Where(x => x.Value.CreateTime + _notificationLifeTime <= now)
                .Select(x => x.Value)
                .ToList();

            foreach (var n in notificationsToRemove)
                CloseNotification(n.Notification);

            if (_notifications.IsEmpty)
                _timer.Stop();
        }


        public event EventHandler<ShowNotificationEventArgs> ShowNotificationRequested;
        public event EventHandler<CloseNotificationEventArgs> CloseNotificationRequested;
    }
}