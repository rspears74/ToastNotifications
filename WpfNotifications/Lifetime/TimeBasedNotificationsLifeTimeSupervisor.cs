using System;
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
        private readonly NotificationsList _notifications;
        private readonly IInterval _interval;

        public TimeBasedNotificationsLifeTimeSupervisor(TimeSpan notificationLifeTime, int maximumNotificationCount, Dispatcher dispatcher)
        {
            _notificationLifeTime = notificationLifeTime;
            _maximumNotificationCount = maximumNotificationCount;
            _dispatcher = dispatcher;

            _notifications =  new NotificationsList();
            _interval = new Interval();
        }

        public void AddNewNotification(INotification notification)
        {
            _notifications.Add(notification);

            _interval.Invoke(frequency: TimeSpan.FromMilliseconds(100),
                dispatcher: _dispatcher,
                action: () =>
                {
                    
                });
        }

        private void CloseNotification(NotificationMetaData notificationMetaData)
        {
//            notificationMetaData.Notification.Close();
//            NotificationMetaData removed;
//            _notifications.TryRemove(notificationMetaData.Index, out removed);
        }

        public void PushNotification(INotification createNotificationFunc)
        {
        }

        public event EventHandler<ShowNotificationEventArgs> ShowNotificationRequested;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void CloseNotification(INotification notification)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<CloseNotificationEventArgs> CloseNotificationRequested;
    }
}