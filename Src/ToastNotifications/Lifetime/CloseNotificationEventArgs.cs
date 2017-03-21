using ToastNotifications.Core;

namespace ToastNotifications.Lifetime
{
    public class CloseNotificationEventArgs
    {
        public INotification Notification { get; }

        public CloseNotificationEventArgs(INotification notification)
        {
            Notification = notification;
        }
    }
}